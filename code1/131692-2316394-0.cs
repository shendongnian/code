     static void Main(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo("c:\\test");
            FileAttributes f = di.Attributes;
            Console.WriteLine("Directory c:\\ has attributes:");
            DecipherAttributes(f);
            
        }
        public static void DecipherAttributes(FileAttributes f)
        {
            
            File.SetAttributes(@"C:\test", FileAttributes.ReadOnly); // LOOK HERE
            if ((f & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                Console.WriteLine("ReadOnly");
           
        }
