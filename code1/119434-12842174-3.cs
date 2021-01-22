        public static bool SendTextFileToPrinter(string szFileName, string printerName)
        {
            var sb = new StringBuilder();
            using (var sr = new StreamReader(szFileName, Encoding.Default)) // Set the correct encoding
            {
                while (!sr.EndOfStream)
                {
                    sb.AppendLine(sr.ReadLine()); // This will automatically fix the last line
                }
            }
            return RawPrinterHelper.SendStringToPrinter(printerName, sb.ToString());
        }
