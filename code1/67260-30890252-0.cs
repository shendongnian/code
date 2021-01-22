    using System.Collections.Generic;
    using System.Xml.Serialization;
    using System.Configuration;
    using System.IO;
    using System.Xml;
    class Program
    {
        static void Main(string[] args)
        {
            var section = SectionSchoool.Load();
            var file = FileSchoool.Load("Scool.xml");
        }
    }
