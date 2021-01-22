    using System;
    using System.IO;
    
    namespace ConsoleApp4
    {
        class Program
        {
            static void Main(string[] args)
            {
                var fi1 = new FileInfo(args[0]);
                var fi2 = new FileInfo(args[1]);
                Console.WriteLine(FilesContentsAreEqual(fi1, fi2));
            }
    
            public static bool FilesContentsAreEqual(FileInfo fileInfo1, FileInfo fileInfo2)
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
                            return StreamsContentsAreEqual(file1, file2);
                        }
                    }
                }
            }
    
            private static int ReadFullBuffer(Stream stream, byte[] buffer)
            {
                int bytesRead = 0;
                while (bytesRead < buffer.Length)
                {
                    int read = stream.Read(buffer, bytesRead, buffer.Length - bytesRead);
                    if (read == 0)
                    {
                        // Reached end of stream.
                        return bytesRead;
                    }
    
                    bytesRead += read;
                }
    
                return bytesRead;
            }
    
            private static bool StreamsContentsAreEqual(Stream stream1, Stream stream2)
            {
                const int bufferSize = 1024 * sizeof(Int64);
                var buffer1 = new byte[bufferSize];
                var buffer2 = new byte[bufferSize];
    
                while (true)
                {
                    int count1 = ReadFullBuffer(stream1, buffer1);
                    int count2 = ReadFullBuffer(stream2, buffer2);
    
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
