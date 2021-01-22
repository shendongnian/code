    class Program
    {
        static void Main(string[] args)
        {
            // get a list of files
            string[] files = Directory.GetFiles(@"D:\backup");
    
            // create new XML document
            XmlDocument xdoc = new XmlDocument();
    
            // add a "root" node
            xdoc.AppendChild(xdoc.CreateElement("ListOfFiles"));
    
            foreach (string file in files)
            {
                xdoc.DocumentElement.AppendChild(CreateXmlElement(xdoc, file));                
            }
    
            // save file
            xdoc.Save(@"D:\filelist.xml");
        }
    
        private static XmlElement CreateXmlElement(XmlDocument xmldoc, string filename)
        {
            XmlElement result = xmldoc.CreateElement("datafile");
            
            result.SetAttribute("name", Path.GetFileName(filename));
            result.SetAttribute("path", Path.GetDirectoryName(filename));
            result.SetAttribute("fullname", filename);
            
            return result;
        }
    }
