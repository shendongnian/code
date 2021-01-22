            string path = Path.Combine(Path.GetTempPath(),
                  Guid.NewGuid().ToString("n"));
            Directory.CreateDirectory(path);
            try
            {
                // work inside path
            }
            finally
            {
                try { Directory.Delete(path, true); }
                catch (Exception ex) {Trace.WriteLine(ex);}
            }
