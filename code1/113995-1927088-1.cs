        XmlSerializer xmls = new XmlSerializer(typeof(SampleNode));
        SampleNode sn = new SampleNode();
        using (FileStream fs = File.Open(@"C:\test.xml", FileMode.Create))
        {
            xmls.Serialize(fs, sn);
        }
        using (FileStream fs = File.OpenRead(@"C:\test.xml"))
        {
            XmlReaderSettings xmlrs = new XmlReaderSettings();
            xmlrs.IgnoreWhitespace = false;
            using (XmlReader xmlr = XmlReader.Create(fs, xmlrs))
            {
                Console.WriteLine("!{0}!", ((SampleNode) xmls.Deserialize(xmlr)).sampleNode); //output: ! !
            }
        }
