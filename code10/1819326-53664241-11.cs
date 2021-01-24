        using (var readStream = new FileStream("Klassifikation_only_Sensor1_01.dr2", FileMode.Open, FileAccess.Read)) {
            using (var reader = new BinaryReader(readStream)) {
                var headerTuple = reader.ReadStruct<CanHeader>();
                Console.WriteLine($"[Header] TimeStampFrequency: {headerTuple.Item1.TimeStampFrequency:x016}  TimeStamp: {headerTuple.Item1.TimeStamp:x016}"); ;
                bool stillWorking;
                UInt64 totalSize = 0L;
                UInt64 recordCount = 0L;
                var chunkSize = (UInt64)Marshal.SizeOf(typeof(CanChunk));
                var chunksWritten = 0;
                FileStream writeStream = null;
                BinaryWriter writer = null;
                var writingChucks = false;
                var allDone = false;
                try {
                    do {
                        var chunkTuple = reader.ReadStruct<CanChunk>();
                        stillWorking = chunkTuple.Item2;
                        if (stillWorking) {
                            var chunk = chunkTuple.Item1;
                            if (!writingChucks && chunk.CanTime % 10_000 == 0) {
                                writingChucks = true;
                                var writeHeader = new CanHeader {
                                    TimeStamp = chunk.TimeStamp,
                                    TimeStampFrequency = headerTuple.Item1.TimeStampFrequency
                                };
                                writeStream = new FileStream("Output.dr2", FileMode.Create, FileAccess.Write);
                                writer = new BinaryWriter(writeStream);
                                writer.WriteStruct(writeHeader);
                            }
                            if (writingChucks && !allDone) {
                                writer.WriteStruct(chunk);
                                ++chunksWritten;
                                if (chunksWritten >= 5000) {
                                    allDone = true;
                                }
                            }
                            totalSize += chunkSize;
                            ++recordCount;
                        }
                    } while (stillWorking);
                } finally {
                    writer?.Dispose();
                    writeStream?.Dispose();
                }
                Console.WriteLine($"Total Size: 0x{totalSize:x016}  Record Count: {recordCount}  Records Written: {chunksWritten}");
            }
        }
    }
