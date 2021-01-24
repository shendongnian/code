        static void Main(string[] args)
        {
            Word.Application wordApp = new Word.Application();
            Word.Document wordDoc = wordApp.Documents.Add();
            Stopwatch sw = Stopwatch.StartNew();
            System.Console.WriteLine("Starting");
            string path = @"C:\";
            StringBuilder stringBuilder = new StringBuilder();
            using (FileStream fs = File.Open(path + "\\big.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                wordDoc.Content.Text = sr.ReadToEnd();
                wordDoc.SaveAs("big.docx");
            }
            sw.Stop();
            System.Console.WriteLine($"Complete Time :{sw.ElapsedMilliseconds}");
            System.Console.ReadKey();
        }
