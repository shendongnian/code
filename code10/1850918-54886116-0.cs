            var index = 1;
            Parallel.ForEach(linkList,  link => { GetDocuments(stopwatch, index++, linkList, documents, link); });
            if (FailedDownloads.Count > 0)
            {
                linkList = new List<string>(FailedDownloads);
                FailedDownloads.Clear();
                Parallel.ForEach(linkList,
                    link => { GetDocuments(stopwatch, index++, linkList, documents, link); });
            }
            return documents;
        }
        private void GetDocuments(Stopwatch stopwatch, int index, List<string> linkList, List<HtmlDocument> documents, string link)
        {
            stopwatch.Restart();
            Console.Write($"Downloading page {index} of {linkList.Count}...");
            try
            {
                documents.Add(LoadPage(link));
                Console.Write($" in {stopwatch.Elapsed.TotalMilliseconds} ms");
            }
            catch (AggregateException e)
            {
                if (e.InnerExceptions[0] is HttpRequestException)
                {
                    FailedDownloads.Add(link);
                    Console.WriteLine(e);
                }
                else
                {
                    throw;
                }
            }
