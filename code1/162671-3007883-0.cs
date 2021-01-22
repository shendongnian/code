    using System;
    using System.CodeDom.Compiler;
    using System.IO;
    
    class Program
    {
        static void Main(string[] args)
        {
            TempFileCollection tfc = new TempFileCollection(Path.GetTempPath());
    
            // add a temporary text file
            string filename1 = tfc.AddExtension("txt");
    
            // add another file with a fully specified name 
            // this file will not automatically be deleted
            string filename2 = Path.Combine(tfc.TempDir, "mycustomfile.txt");
            tfc.AddFile(filename2, true);
            Console.WriteLine(tfc.Count);
            // Create and use the test files.
            File.WriteAllText(filename1, "Hello World.");
            File.WriteAllText(filename2, "Hello again.");
            tfc.Delete();
        }
    }
    
