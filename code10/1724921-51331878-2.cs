        public void ReadProjectInfo()
        {
            //...
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "caseInformation")
                    {
                        ReadCaseInformation(reader.ReadSubtree());
                    }
                }
            }
        }
        public void ReadCaseInformation(XmlReader reader)
        {
            try
            {
                // if something raise an exception here
                // the main reader is not really affected by that
                // because when the methods ends, the "subReader" is closed
                // and then the main reader is set on the closing tag.
                // so the main XML reader can continue to analyze the xml stream
            }
            catch (Exception)
            {
                //...
            }
        }
