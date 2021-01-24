    public class Sample
    {
        public void Delete(string folder, int days)
        {
            var files = GetFiles(folder);
    
            foreach (var file in files)
            {
                var fi = GetFileInfo(file);
                var fiCreationTime = fi.CreationTime;
                var deleteOlderThan = DateTime.Now.AddDays(-days);
    
                if (fiCreationTime >= deleteOlderThan) continue;
                DeleteFile(fi);
            }
        }
    
        public virtual void DeleteFile(FileInfo f)
        {
            f.Delete();
        }
    
        public virtual string[] GetFiles(string path)
        {
            return Directory.GetFiles(path);
        }
    
        public virtual FileInfo GetFileInfo(string file)
        {
            return new FileInfo(file);
        }
    }
