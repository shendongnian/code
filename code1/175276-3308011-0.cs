    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    
    
    namespace rem2ndline
    {
        class Program
        {
            static void Main(string[] args)
            {
                string inPath = @"c:\rem2ndline.txt";
                string outPath = @"c:\rem2ndlineresult.txt";
                StringBuilder builder = new StringBuilder();
    
                using (FileStream fso = new FileStream(inPath, FileMode.Open))
                {
                    using (StreamReader rdr = new StreamReader(fso))
                    {
                        int lineCount = 0;
                        bool canRead = true;
                        while (canRead) 
                        {
                            var line = rdr.ReadLine();
                            lineCount++;
                            if (line == null)
                            {
                                canRead = false;
                            }
                            else
                            {
                                if (lineCount != 2)
                                {
                                    builder.AppendLine(line);   
                                }
                            }
                        }
                    }
    
                }
    
                using(FileStream fso2 = new FileStream(outPath, FileMode.OpenOrCreate))
                {
                    using (StreamWriter strw = new StreamWriter(fso2)) 
                    {
                        strw.Write(builder.ToString());
                    }
                }
            }
        }
    }
