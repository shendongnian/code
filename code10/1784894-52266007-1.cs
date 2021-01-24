    using System.IO;
    
    class Program
    {  
        static public void Main()
        {
            string Path = @"\\test-file-server-name\Scripts\";
            string[] fileEntries = Directory.GetFiles(Path, "Cartons_*");
    
            foreach (string filename in fileEntries)
            {
                if (filename.Contains("Cartons"))
                {
                    File.Move(filename, Path + "Cartons.csv");
                }
            }
            // TODO: Add your code here
    
            //Dts.TaskResult = (int)ScriptResults.Success;
        }
    }
