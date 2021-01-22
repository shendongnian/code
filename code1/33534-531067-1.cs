            XmlReaderSettings settings = new XmlReaderSettings(){
            settings.IgnoreComments = true;
            using (XmlReader reader = XmlReader.Create("Test.xml",settings)){
                while(reader.Read()){
                    // Construct/Evaluate XML Here....
                }
                reader.Close();
            }
        }
