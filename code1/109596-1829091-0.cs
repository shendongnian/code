    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string alphaFilePath = @"C:\Documents and Settings\Jason\My Documents\Visual Studio 2008\Projects\Compte Two Files\Compte Two Files\ExternalFiles\Alpha.txt";
    
                List<string> alphaFileContent = new List<string>();
    
                using (FileStream fs = new FileStream(alphaFilePath, FileMode.Open))
                using(StreamReader rdr = new StreamReader(fs))
                {
                    while(!rdr.EndOfStream)
                    {
                        alphaFileContent.Add(rdr.ReadLine());
                    }
                }
    
                string betaFilePath = @"C:\Beta.csv";
    
                StringBuilder sb = new StringBuilder();
                           
    
                using (FileStream fs = new FileStream(betaFilePath, FileMode.Open))
                using (StreamReader rdr = new StreamReader(fs))
                {
                    while(! rdr.EndOfStream)
                    {
                        string[] betaFileLine = rdr.ReadLine().Split(Convert.ToChar(","));
    
                        if (alphaFileContent.Contains(betaFileLine[0]))
                        {
                            sb.AppendLine(String.Format("{0}, {1}", betaFileLine[0], betaFileLine[1]));
                        }
                    }
                }
    
                Console.WriteLine(sb.ToString());
            }
        }
    }
