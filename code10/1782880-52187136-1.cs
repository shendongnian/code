        private Task Execute()
        {
            var Tasks = new List<Task>(Queries.Count);
    
            foreach (var query in Queries)
            {
                // call Execute with Query filter or Downloader.Filter
                var task = query.Execute(query.IsOwnFilter ? query.Filter : Filter, CancellationToken);
                Tasks.Add(task);
            }
    
            return Task.WhenAll(Tasks);
        }
