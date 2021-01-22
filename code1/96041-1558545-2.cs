    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    
    
    namespace ConsoleApplication6
    {
        class Program
        {
            static void Main(string[] args)
            {
                foreach (string fileName in Directory.GetFiles("C:\\abc\\", "*.mol"))
                {
                   bool shouldAddMEnd = false;
                   using (System.IO.StreamReader sw = new System.IO.StreamReader(fileName))
                   {
                       shouldAddMEnd = !sw.ReadToEnd().EndsWith("M  END");                        
                   } 
                   if (shouldAddMEnd)
                       File.AppendAllText(fileName, "M  END" + Environment.NewLine);
                 }
             }
        }
    }
