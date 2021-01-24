    public static void ReadBinary() {
        using (var stream = new FileStream("Klassifikation_only_Sensor1_01.dr2", FileMode.Open, FileAccess.Read)) {
            using (var reader = new BinaryReader(stream)) {
                var headerTuple = reader.ReadStruct<CanHeader>();
                Console.WriteLine($"[Header] TimeStampFrequency: {headerTuple.Item1.TimeStampFrequency:x016}  TimeStamp: {headerTuple.Item1.TimeStamp:x016}");;
                bool stillWorking;
                UInt64 totalSize = 0L;
                var chunkSize = (UInt64)Marshal.SizeOf(typeof(CanChunk));
                do {
                    var chunkTuple = reader.ReadStruct<CanChunk>();
                    stillWorking = chunkTuple.Item2;
                    if (stillWorking) {
                        var chunk = chunkTuple.Item1;
                        //Console.WriteLine($"{chunk.ReturnReadValue:x08} {chunk.CanTime:x08} {chunk.Can:x08} {chunk.Ident:x08} {chunk.DataLength:x08} {chunk.Data:x016} {chunk.Res:x04} {chunk.TimeStamp:x016}");
                        totalSize += chunkSize;
                    }
                } while (stillWorking);
                Console.WriteLine($"Total Size: 0x{totalSize:x016}");
            }
        }
    }
