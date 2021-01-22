    using System;
    using System.IO;
    using System.Threading.Tasks;
    
    namespace ConsoleApp4
    {
        class Program
        {
            static void Main(string[] args)
            {
                var fi1 = new FileInfo(args[0]);
                var fi2 = new FileInfo(args[1]);
                Console.WriteLine(FilesContentsAreEqualAsync(fi1, fi2).GetAwaiter().GetResult());
            }
    
            public static async Task<bool> FilesContentsAreEqualAsync(FileInfo fileInfo1, FileInfo fileInfo2)
            {
                if (fileInfo1 == null)
                {
                    throw new ArgumentNullException(nameof(fileInfo1));
                }
    
                if (fileInfo2 == null)
                {
                    throw new ArgumentNullException(nameof(fileInfo2));
                }
    
                if (string.Equals(fileInfo1.FullName, fileInfo2.FullName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
    
                if (fileInfo1.Length != fileInfo2.Length)
                {
                    return false;
                }
                else
                {
                    using (var file1 = fileInfo1.OpenRead())
                    {
                        using (var file2 = fileInfo2.OpenRead())
                        {
                            return await StreamsContentsAreEqualAsync(file1, file2).ConfigureAwait(false);
                        }
                    }
                }
            }
    
            private static async Task<int> ReadFullBufferAsync(Stream stream, byte[] buffer)
            {
                int bytesRead = 0;
                while (bytesRead < buffer.Length)
                {
                    int read = await stream.ReadAsync(buffer, bytesRead, buffer.Length - bytesRead).ConfigureAwait(false);
                    if (read == 0)
                    {
                        // Reached end of stream.
                        return bytesRead;
                    }
    
                    bytesRead += read;
                }
    
                return bytesRead;
            }
    
            private static async Task<bool> StreamsContentsAreEqualAsync(Stream stream1, Stream stream2)
            {
                const int bufferSize = 1024 * sizeof(Int64);
                var buffer1 = new byte[bufferSize];
                var buffer2 = new byte[bufferSize];
    
                while (true)
                {
                    int count1 = await ReadFullBufferAsync(stream1, buffer1).ConfigureAwait(false);
                    int count2 = await ReadFullBufferAsync(stream2, buffer2).ConfigureAwait(false);
    
                    if (count1 != count2)
                    {
                        return false;
                    }
    
                    if (count1 == 0)
                    {
                        return true;
                    }
    
                    int iterations = (int)Math.Ceiling((double)count1 / sizeof(Int64));
                    for (int i = 0; i < iterations; i++)
                    {
                        if (BitConverter.ToInt64(buffer1, i * sizeof(Int64)) != BitConverter.ToInt64(buffer2, i * sizeof(Int64)))
                        {
                            return false;
                        }
                    }
                }
            }
        }
    }
