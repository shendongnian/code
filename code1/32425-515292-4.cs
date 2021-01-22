        static int GetVersion(XmlNode element, string xpath) {
            return int.Parse(element.SelectSingleNode(xpath).InnerText);
        }
        static void Main() {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            Version bestVersion = null;
            List<XmlElement> files = new List<XmlElement>();
            foreach (XmlElement file in doc.SelectNodes(
                     "/GateKeeperFiles/File")) {
                Version version = new Version(
                    GetVersion(file, "Major"), GetVersion(file, "Minor"),
                    GetVersion(file, "Build"), GetVersion(file, "Revision"));
                if (bestVersion == null || version > bestVersion) {
                    bestVersion = version;
                    files.Clear();
                    files.Add(file);
                } else if (version == bestVersion) {
                    files.Add(file);
                }
            }
            Console.WriteLine("Version: " + bestVersion);
            foreach (XmlElement file in files) {
                Console.WriteLine(file.SelectSingleNode("Name").InnerText);
            }
        }
