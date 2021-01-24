        public static Task<Stream> ReadAsStreamAsync(this HttpContent content, bool isChunked)
        {
            if (!isChunked)
            {
                return content.ReadAsStreamAsync();
            }
            else
            {
                var task = content.ReadAsStreamAsync()
                .ContinueWith<Stream>((streamTask) =>
                {
                    var outputStream = new MemoryStream();
                    var buffer = new char[1024 * 1024];
                    var stream = streamTask.Result;
                    // No using() so that we don't dispose stream.
                    var tr = new StreamReader(stream);
                    var tw = new StreamWriter(outputStream);
                    while (!tr.EndOfStream)
                    {
                        var chunkSizeStr = tr.ReadLine().Trim();
                        var chunkSize = int.Parse(chunkSizeStr, System.Globalization.NumberStyles.HexNumber);
                        tr.ReadBlock(buffer, 0, chunkSize);
                        tw.Write(buffer, 0, chunkSize);
                        tr.ReadLine();
                    }
                    return outputStream;
                });
                return task;
            }
            
        }
