    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    
    namespace ConsoleApplication61
    {
    class Program
    {
        static void Main(string[] args)
        {
    
            StreamReader inFile;
            string inLine;
            
            //PTK: patern for your fields
            Regex rPattern= new Regex(@"\'([^'\s]+)[\'\s]+([^'\s]+)[\'\s]+([^'\s]+)[\'\s]+\)[\'\s]+([^'\s]+)[\'\s]+([^'\s]+)[\'\s]+([^'\s]+)");
   
            if (File.Exists("Students2.txt"))
            {
                try
                {
    
    
    
                    using (StreamWriter Malachi = File.AppendText("Students2.txt"))
                    {
                        Malachi.WriteLine("(LIST (LIST 'Constant 'Malachi 'J ) '1832878847 'mconstant@mail.usi.edu 4.0000000000000000 )");
                    }
    
                    inFile = new StreamReader("Students2.txt");
                    while ((inLine = inFile.ReadLine()) != null)
                    {
                     //PTK: match the current line with the pattern
                     Match m = rPattern.Match(inLine );
        
                     if(m.Success)
                     {
                        string lastname = m.Groups[1].Value;
                        string firstname = m.Groups[2].Value;
                        string middlename = m.Groups[3].Value;
                        string phone = m.Groups[4].Value;
                        string email = m.Groups[5].Value;
                        string somenumber = m.Groups[6].Value;
                        Console.WriteLine( lastname + firstname );
                     }
  
                    }
                }
    
    
                catch (System.IO.IOException exc)
                {
                    Console.WriteLine("Error");
                }
            }
        }
    }
    }
