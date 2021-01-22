            [Test]
            public void RaceFileMerges()
            {
                var inputFilesPath = @"D:\InputFiles";
                var inputFiles = Directory.EnumerateFiles(inputFilesPath).ToArray();
    
                var sw = new Stopwatch();
                sw.Start();
    
                ConcatenateFilesUsingReadAllBytes(@"D:\ReadAllBytesResult", inputFiles);
    
                Console.WriteLine($"ReadAllBytes method in {sw.Elapsed}");
    
                sw.Reset();
                sw.Start();
    
                ConcatenateFiles(@"D:\CopyToResult", inputFiles);
    
                Console.WriteLine($"CopyTo method in {sw.Elapsed}");
            }
            
            private static void ConcatenateFiles(string outputFile, params string[] inputFiles)
            {
                using (var output = File.OpenWrite(outputFile))
                {
                    foreach (var inputFile in inputFiles)
                    {
                        using (var input = File.OpenRead(inputFile))
                        {
                            input.CopyTo(output);
                        }
                    }
                }
            }
    
            private static void ConcatenateFilesUsingReadAllBytes(string outputFile, params string[] inputFiles)
            {
                using (var stream = File.OpenWrite(outputFile))
                {
                    foreach (var inputFile in inputFiles)
                    {
                        var currentBytes = File.ReadAllBytes(inputFile);
                        stream.Write(currentBytes, 0, currentBytes.Length);
                    }
                }
            }
