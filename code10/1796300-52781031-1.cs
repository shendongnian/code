        internal static byte[] ConvertToBytes(object data)
        {
            using (var uncompressedStream = new ChunkedMemoryStream())
            {
                SerializerModel.Serialize(uncompressedStream, data);
                if (_typesToCompress.Contains(data.GetType()))
                    using (var compressedStream = new ChunkedMemoryStream())
                    {
                        var head = DateTime.Now;
                        using (var lz4 = new LZ4Stream(compressedStream, LZ4StreamMode.Compress, LZ4StreamFlags.IsolateInnerStream))
                        using (var writer = new BinaryWriter(lz4))
                        {
                            foreach (var chunk in uncompressedStream.Chunks)
                            {
                                writer.Write(chunk);
                            }
                        }
                        if (uncompressedStream.Length > 0)
                            LogService.Enqueue(
                                $"Сжато {uncompressedStream.Length - compressedStream.Length} байт ({100 - 100.0 * compressedStream.Length / uncompressedStream.Length:0.0}% от объема) {data.GetType().Name} за {(DateTime.Now - head).TotalMilliseconds:0.0} мс",
                                LogTextType.Warning);
                        return compressedStream.ToArray();
                    }
                return uncompressedStream.ToArray();
            }
        }
