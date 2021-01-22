    class PdfPage
    {
        public string content { get; set; }
        public List<PdfRow> rows
        {
            get
            {
                if (string.IsNullOrEmpty(content))
                    return null;
                //split by newline to get all the rows with text
                return content.Split('\n').Select(x => new PdfRow()
                {
                    content = x
                }).ToList();
            }
        }
    }
    class PdfRow
    {
        public string content { get; set; }
        public List<string> words
        {
            get
            {
                if (string.IsNullOrEmpty(content))
                    return null;
                //split by space to get the individual words
                return content.Split(' ').ToList();
            }
        }
    }
