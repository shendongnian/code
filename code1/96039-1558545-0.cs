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
    
                    using(System.IO.StreamReader file = new System.IO.StreamReader(fileName)) {                      
                    if (!sw.ReadToEnd().EndsWith("M  END"))
                    {
                        File.AppendAllText(fileName, "M  END" + Environment.NewLine);
    
                    }
                  }    
                }
    
            }
        }
    }
