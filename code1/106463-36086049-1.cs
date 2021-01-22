        Dictionary<string, DateTime> dateTimeDictionary = new Dictionary<string, DateTime>(); 
        
            private void OnChanged(object source, FileSystemEventArgs e)
                {
                    if (!dateTimeDictionary.ContainsKey(e.FullPath) || (dateTimeDictionary.ContainsKey(e.FullPath) && System.IO.File.GetLastWriteTime(e.FullPath) != dateTimeDictionary[e.FullPath]))
                    {
                        dateTimeDictionary[e.FullPath] = System.IO.File.GetLastWriteTime(e.FullPath);
                        
                        //your code here
                    }
                }
