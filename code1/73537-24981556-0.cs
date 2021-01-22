        using System.IO.Compression;
        using System.Xml;
        using System.Xml.Linq;
        static IEnumerable<string> GetWorksheetNamesOrdered(string fileName)
        {
            //open the excel file
            using (FileStream data = new FileStream(fileName, FileMode.Open))
            {
                //unzip
                ZipArchive archive = new ZipArchive(data);
                //select the correct file from the archive
                ZipArchiveEntry appxmlFile = archive.Entries.SingleOrDefault(e => e.FullName == "docProps/app.xml");
                //read the xml
                XDocument xdoc = XDocument.Load(appxmlFile.Open());
                //find the titles element
                XElement titlesElement = xdoc.Descendants().Where(e => e.Name.LocalName == "TitlesOfParts").Single();
                //extract the worksheet names
                return titlesElement
                    .Elements().Where(e => e.Name.LocalName == "vector").Single()
                    .Elements().Where(e => e.Name.LocalName == "lpstr")
                    .Select(e => e.Value);
            }
        }
