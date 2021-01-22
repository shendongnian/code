            XmlReaderSettings settings = new XmlReaderSettings()){
            settings.IgnoreComments = true;
            using (XmlReader reader = XmlReader.Create("Test.xml",settings)){
                while(reader.Read()){
                    // Construct/Eval XML Here....
                }
                reader.Close();
            }
        }
