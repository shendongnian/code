    void DirSearch(string path)
        {
            ConcurrentQueue<string> pendingQueue = new ConcurrentQueue<string>();
            pendingQueue.Enqueue(path);
            ConcurrentBag<string> filesNames = new ConcurrentBag<string>();
            while(pendingQueue.Count > 0)
            {
                try
                {
                    pendingQueue.TryDequeue(out path);
                    var files = Directory.GetFiles(path);
                    Parallel.ForEach(files, x => filesNames.Add(x));
                    var directories = Directory.GetDirectories(path);
                    Parallel.ForEach(directories, (x) => pendingQueue.Enqueue(x));
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }
