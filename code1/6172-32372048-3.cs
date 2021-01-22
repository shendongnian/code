        private Encoding GetEncodingFromString(string codePageName)
        {
            try
            {
                return Encoding.GetEncoding(codePageName);
            }
            catch
            {
                return Encoding.ASCII;
            }
        }
