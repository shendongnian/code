     Stream baseStream = new MemoryStream();
                    StreamWriter csvWriter = new StreamWriter(baseStream, Encoding.UTF8);
                    csvWriter.Write(results);
                    csvWriter.Flush();
                    baseStream.Seek(0, SeekOrigin.Begin);
                    Console.WriteLine(baseStream.Length);
                    return baseStream;
