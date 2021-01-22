        private byte[] FromHexString(string encryptedToken)
        {
            List<byte> bytes = new List<byte>();
            for (int i = 0; i <= encryptedToken.Length; i+=2)
            {
                try
                {
                    bytes.Add((byte)Int32.Parse(encryptedToken.Substring(i, 2), System.Globalization.NumberStyles.HexNumber));
                }
                catch //whatever exception
                {
                    //handle
                }
                
            }
            return bytes.ToArray();
        }      
