    using Microsoft.Win32;
    public class FileAssoc
    {
        public string Extension;
        public string Filetype;
    
        public FileAssoc(string fileext, string name)
        {
            Extension = fileext;
            Filetype = name;
        }
    }
    public static class EnumRegFiles
    {
        public static List<FileAssoc> GetFileAssociations()
        {
            List<FileAssoc> result = new List<FileAssoc>();
            RegistryKey rk = Registry.ClassesRoot;
    
            String[] names = rk.GetSubKeyNames();
            foreach (string file in names)
            {
                if (file.StartsWith("."))
                {
                    RegistryKey rkey = rk.OpenSubKey(file);
                    object descKey = rkey.GetValue("");
    
                    if (descKey != null)
                    {
                        string desc = descKey.ToString();
                        if (!string.IsNullOrEmpty(desc))
                        {
                            result.Add(new FileAssoc(file, desc));
                        }
                    }
                }
            }
    
            return result;
        }
    }
