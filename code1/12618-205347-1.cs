    class Program
    {
        static void Main(string[] args)
        {
            XmlWriter w = XmlTextWriter.Create("./foo.xml");
            w.WriteStartElement("foo");
            w.WriteString(" THIS   HAS VARYING     SPACeS ");
            w.WriteEndElement();
            w.Close();
    
            StreamReader sr = new StreamReader("./foo.xml");
            Console.WriteLine(sr.ReadToEnd());
            Console.ReadKey();
        }
    }
