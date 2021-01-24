    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                //or Create(Stream)
                XmlReader reader = XmlReader.Create(FILENAME);
                reader.ReadToFollowing("modelData");
                if (!reader.EOF)
                {
                    string modelDataStr = reader.ReadOuterXml();
                }
            }
        }
    }
