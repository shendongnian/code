        private static string FindPdfFileDownloadLink(string htmlContent)
        {
            return Regex.Match(htmlContent, @"^(https?:\/\/)?www\.([\da-z\.-]+)\.([a-z\.]{2,6})\/[\w \.-]+?\.pdf$").Value;
        }
        public static int Main(string[] args)
        {
            string htmlContent = File.ReadAllText("1.html");
            string pdfUrl = FindPdfFileDownloadLink(htmlContent);
            using (WebClient wClient = new WebClient())
            {
                wClient.DownloadFile(pdfUrl, @"1.pdf");
            }
            Console.Read();
            return 0;
        }
