    private static void OnCreated(object source, FileSystemEventArgs e)
        {
            try
            {
                Thread.Sleep(5000);
                var data = new FileData();
                data.ReadFile(e.FullPath);                
            }
            catch (Exception ex)
            {
                WriteLogforError(ex.Message, String.Empty, filepath);
            }
        }
