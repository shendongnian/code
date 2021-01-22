    private string[] FindFiles(string directory, string filters, SearchOption searchOption)
    {
        if (!Directory.Exists(directory)) return new string[] { };
        var include = (from filter in filters.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries) where !string.IsNullOrEmpty(filter.Trim()) select filter.Trim());
        var exclude = (from filter in include where filter.Contains(@"!") select filter);
        include = include.Except(exclude);
        if (include.Count() == 0) include = new string[] { "*" };
        var rxfilters = from filter in exclude select string.Format("^{0}$", filter.Replace("!", "").Replace(".", @"\.").Replace("*", ".*").Replace("?", "."));
        Regex regex = new Regex(string.Join("|", rxfilters.ToArray()));
        List<Thread> workers = new List<Thread>();
        List<string> files = new List<string>();
        foreach (string filter in include)
        {
            Thread worker = new Thread(
                new ThreadStart(
                    delegate
                    {
                        string[] allfiles = Directory.GetFiles(directory, filter, searchOption);
                        if (exclude.Count() > 0)
                        {
                            lock (files)
                                files.AddRange(allfiles.Where(p => !regex.Match(p).Success));
                        }
                        else
                        {
                            lock (files)
                                files.AddRange(allfiles);
                        }
                    }
                ));
            workers.Add(worker);
            worker.Start();
        }
        foreach (Thread worker in workers)
        {
            worker.Join();
        }
        return files.ToArray();
    }
