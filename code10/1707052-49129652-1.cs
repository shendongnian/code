    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            private const String XmlPath = @"..\..\TestCases\";
            static void Main(string[] args)
            {
                string xml = "<Root>";
                foreach (string file in Directory.GetFiles(XmlPath))
                {
                    StreamReader reader = new StreamReader(file, Encoding.UTF8);
                    //skip identification line
                    reader.ReadLine();
                    xml += reader.ReadToEnd();
                }
                xml += "</Root>";
            }
        }
    }
