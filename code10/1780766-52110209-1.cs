    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.IO;
    
    namespace ConsoleApp3
    {
        public class Program
        {
            static void Main(string[] args)
            {
                using (TextReader tr = new StreamReader(@"C:\Users\Admin\Desktop\test.xml"))
                {
                    XDocument document = XDocument.Load(tr);
                    var allDescendants = document.Descendants("Value");
                    Console.WriteLine(allDescendants.Select(x=>x.Value).Aggregate((x,y)=> x+","+y));
                }                
            }
        }
    }
