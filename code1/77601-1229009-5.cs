    using System;
    using System.IO;
    using System.Text;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main()
        {
            string xml = @"<?xml version='1.0' encoding='utf-8'?>
    <Cooperations>
      <Cooperation />
    </Cooperations>";
            
            XDocument doc = XDocument.Parse(xml);
            StringBuilder builder = new StringBuilder();
            using (TextWriter writer = new StringWriter(builder))
            {
                doc.Save(writer);
            }
            Console.WriteLine(builder);
        }
    }
