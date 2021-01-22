            List<string> returnFolders = new List<string>();
            object locker = new object();
            Parallel.ForEach(subFolders, subFolder =>
            {
                if (subFolder.ToUpper().EndsWith(yourKeyword))
                {
                    lock (locker)
                    {
                        returnFolders.Add(subFolder);
                    }
                }
                else
                {
                    lock (locker)
                    {
                        returnFolders.AddRange(GetFolders(Directory.GetDirectories(subFolder)));
                    }
                }
            });
            return returnFolders;
