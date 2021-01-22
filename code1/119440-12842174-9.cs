        public static bool SendTextFileToPrinter(string szFileName, string printerName)
        {
            var sb = new StringBuilder();
            using (var sr = new StreamReader(szFileName, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    sb.AppendLine(sr.ReadLine());
                }
            }
            return RawPrinterHelper.SendStringToPrinter(printerName, sb.ToString());
        }
