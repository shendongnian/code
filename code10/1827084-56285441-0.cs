    private string ParsePDF(string filepathname)
        {
            PdfDocument document = new PdfDocument();
            document.LoadFromFile(filepathname);
            StringBuilder content = new StringBuilder();
           string tex =  content.Append(document.Pages[0].ExtractText()).ToString();
            MessageBox.Show(tex);
            string pattern;
            pattern = @"\d{2,}.\d{2,}.\d{2,}";// 01_01_2019
            var m = Regex.Match(tex, pattern);
            if (!string.IsNullOrEmpty(m.Value))
            {
                return m.Value.Substring(0);
            }
            return "";           
        }
