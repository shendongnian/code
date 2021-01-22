    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo("c:\\test");
            FileAttributes f = di.Attributes;
            
            Console.WriteLine("Directory c:\\test has attributes:");
            DecipherAttributes(f);
            
        }
        public static void DecipherAttributes(FileAttributes f)
        {
            // To set use File.SetAttributes
            File.SetAttributes(@"C:\test", FileAttributes.ReadOnly);
            if ((f & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                Console.WriteLine("ReadOnly");
            // To remove readonly use "-="
            f -= FileAttributes.ReadOnly;
            if ((f & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                Console.WriteLine("ReadOnly");
            else
                Console.WriteLine("Not ReadOnly");
        }
    }
