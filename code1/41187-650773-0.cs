        private void RemoveShortCutFolder(string folder)
        {
            folder = folder.Replace("\"  ", "");
            folder = Path.Combine(Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("ALLUSERSPROFILE"), "Start Menu"), "Programs"), folder);
            try
            {
                if (System.IO.Directory.Exists(folder))
                {
                    System.IO.Directory.Delete(folder, true);
                }
                else
                {
                }
            }
            catch (Exception)
            {
            }
        }
