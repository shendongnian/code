    public class DocumentConverter
    {
        #region Singleton
        static DocumentConverter _documentConverter = null;
        private DocumentConverter() { }
        public static DocumentConverter Instance
        {
            get
            {
                if (_documentConverter == null)
                {
                    _documentConverter = new DocumentConverter();
                }
                return _documentConverter;
            }
        }
        #endregion
        public bool CsvToXml(string sourcePath, string destinationPath)
        {
            var success = false;
            var fileExists = File.Exists(sourcePath);
            if (!fileExists)
            {
                return success;
            }
            var formatedLines = LoadCsv(sourcePath);
            var headers = formatedLines[0].Split(',').Select(x => x.Trim('\"').Replace(" ", string.Empty)).ToArray();
            var xml = new XElement("VendorParts",
               formatedLines.Where((line, index) => index > 0).
                   Select(line => new XElement("Part",
                      line.Split(',').Select((field, index) => new XElement(headers[index], field)))));
            try
            {
                xml.Save(destinationPath);
                success = true;
            }
            catch (Exception ex)
            {
                success = false;
                var baseException = ex.GetBaseException();
                Debug.Write(baseException.Message);
            }
            return success;
        }
        private List<string> LoadCsv(string sourcePath)
        {
            var lines = File.ReadAllLines(sourcePath).ToList();
            var formatedLines = new List<string>();
            foreach (var line in lines)
            {
                var formatedLine = line.TrimEnd(',');
                formatedLines.Add(formatedLine);
            }
            return formatedLines;
        }
    }
