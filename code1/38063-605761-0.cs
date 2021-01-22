    using System;
    using System.Xml;
    using System.Xml.Xsl;
    namespace XsltTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                XslCompiledTransform xslt = new XslCompiledTransform();
                xslt.Load("test.xslt");
                XmlWriter xw = XmlWriter.Create(Console.Out);
                xslt.Transform("input.xml", xw);
                xw.Flush();
                xw.Close();
                Console.ReadKey();
            }
        }
    }
