            foreach (string file in Directory.EnumerateFiles(rootDirectory, "*", SearchOption.AllDirectories))
            {
                if (!((IList<string>)validTypes).Contains(Path.GetExtension(file)))
                {
                    continue;
                }
                string path = file;
                ThreadPool.QueueUserWorkItem(delegate { doStuff(path); });
            }
