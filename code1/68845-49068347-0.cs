    public string getUniqueFileName(int i, string filepath, string filename)
        {
            string path = Path.Combine(filepath, filename);
            if (System.IO.File.Exists(path))
            {
                string name = Path.GetFileNameWithoutExtension(filename);
                string ext = Path.GetExtension(filename);
                i++;
                filename = getUniqueFileName(i, filepath, name + "_" + i + ext);
            }
            return filename; 
        }
