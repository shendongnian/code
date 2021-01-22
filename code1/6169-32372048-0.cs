        private Encoding GetEncodingFromString(string encoding)
        {
            foreach (var encodingInfo in Encoding.GetEncodings())
            {
                if (encodingInfo.Name.ToLower().Equals(encoding.ToLower()))
                {
                    return encodingInfo.GetEncoding();
                }
            }
            return Encoding.ASCII;
        }
