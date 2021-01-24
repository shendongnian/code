        private CancellationTokenSource _cts;
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearch.Enabled = false;
            lvSearchResults.Clear();
            _cts = new CancellationTokenSource();
            AddResults(await Task.Run(() => RunSearch(GetItems(), GetWorkerCount(), _cts.Token)));
            btnSearch.Enabled = true;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
        }
        private List<Result> RunSearch(List<Item> items, int workerCount, CancellationToken ct)
        {
            ConcurrentBag<List<Result>> allResults = new ConcurrentBag<List<Result>>();
            try
            {
                Parallel.ForEach(items, new ParallelOptions() { MaxDegreeOfParallelism = workerCount, CancellationToken = ct }, (item) =>
                {
                    Search search = new Search(); // you could instanciate this elseware as long as it's thread safe...
                    List<Result> results = search.DoWork(item);
                    allResults.Add(results);
                });
            }
            catch (OperationCanceledException)
            { }
            return allResults.SelectMany(r => r).ToList();
        }
        private void AddResults(List<Result> results)
        {
            if (results.Count > 0)
                lvSearchResults.Items.AddRange(results.Select(r => new ListViewItem(r.ToString())).ToArray());
        }
