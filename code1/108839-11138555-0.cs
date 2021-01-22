        [Test]
        public void TestDownloadThreadsImpactToSpeed()
        {
            var sampleImages = Enumerable.Range(0, 100)
                .Select(x => "url to some quite large file from good server which does not have anti DSS stuff.")
                .ToArray();            
            for (int i = 0; i < 8; i++)
            {
                var start = DateTime.Now;
                var threadCount = (int)Math.Pow(2, i);
                Parallel.For(0, sampleImages.Length - 1, new ParallelOptions {MaxDegreeOfParallelism = threadCount},
                             index =>
                                 {
                                     using (var webClient = new WebClient())
                                     {
                                         webClient.DownloadFile(sampleImages[index],
                                                                string.Format(@"c:\test\{0}", index));
                                     }
                                 });
                Console.WriteLine("Number of threads: {0}, Seconds: {1}", threadCount, (DateTime.Now - start).TotalSeconds);
            }
        }
