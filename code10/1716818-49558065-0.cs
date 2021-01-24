    namespace csharp1
    {
        class Program
        {
            public struct Abc
            {
                public string s1;
            };
    
            static  Abc obj = new Abc();
    
            static void Main(string[] args)
            {
                System.Console.WriteLine("start main");
                string cwd      = Directory.GetCurrentDirectory();
                string fileName = "Myfile.xml";
                string destFile = System.IO.Path.Combine(cwd, fileName);
                string inpFile  = "MyfileINP.xml";
                string inpDir   = System.IO.Path.Combine(cwd, "SubDir");
                string srcfile  = System.IO.Path.Combine(inpDir, inpFile);
                File.Copy(srcfile, destFile, false);
                string mains1 = obj.s1;
            }
        }
    }
