    public static class ScanAndSerialize
    {
        public static void Serialize()
        {
            List<string> dirs = FileHelper.GetFilesRecursive(@"s:\project\");
    
    
            XmlSerializer SerializeObj = new XmlSerializer(dirs.GetType());
            string sDay = DateTime.Now.ToString("MMdd");
            string fileName = string.Format(@"s:\project\{0}_file.xml", sDay);
            TextWriter WriteFileStream = new StreamWriter(fileName);
            SerializeObj.Serialize(WriteFileStream, dirs);
            WriteFileStream.Close();
    
    
        }
    }
    
    static class FileHelper
    {
        public static List<string> GetFilesRecursive(string b)
        {
            List<string> result = new List<string>();
    
            var stack = new Stack<DirectoryInfo>();
            stack.Push(new DirectoryInfo (b));
    
            while (stack.Count > 0)
            {
                var dirInfo = stack.Pop();
                string dir = dirInfo.FullName;
    
                try
                {
                    result.AddRange(Directory.GetFiles(dir, "*.*"));
    
    
                    foreach (string dn in Directory.GetDirectories(dir))
                    {
                        DirectoryInfo dirInfo = new DirectoryInfo(dn);
                        dirInfo.Name.ToString();
                        dirInfo.Attributes.ToString();
                        dirInfo.CreationTime.ToString();
                        dirInfo.Exists.ToString();
                        dirInfo.LastAccessTime.ToString();
                        dirInfo.LastWriteTime.ToString();
    
                        stack.Push(dirInfo);
    
                    }
    
    
                }
                catch
                {
    
                }
            }
            return result;
        }
    
    }
