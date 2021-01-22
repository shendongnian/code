    using System.Xml.Serialization;
    static void Main()
        {
            // Get all files in Documents
            List<string> dirs = FileHelper.GetFilesRecursive(@"S:\\bob.smith\\");
    
            XmlSerializer x = new XmlSerializer(dirs.GetType());
            x.Serialize(Console.Out, dirs);
            
    
            
            Console.Read();
        }
