            Parallel.ForEach(linkList, link => 
            {
                try
                {
                    stopwatch.Restart();
                    Console.Write($"Downloading page {index++} of {linkList.Count}...");
                    documents.Add(LoadPage(link));
                    Console.Write($" in {stopwatch.Elapsed.TotalMilliseconds} ms");
                    Console.WriteLine();
                }
                catch (Exception e)
                {
                    ???
                }
            });
            return documents;
