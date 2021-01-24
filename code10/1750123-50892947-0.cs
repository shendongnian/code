    client.DownloadDataCompleted += (s, e) =>
             {
                var text = e.Result;
                // look at your parameters 
                File.WriteAllText(destination, Path.Combine(destination, Utils.getFileName(url)));
                OnSuccess((Object)Path.Combine(destination, Utils.getFileName(url)));
             };
