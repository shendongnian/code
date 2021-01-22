    public static class StringExtentions
        {
            /// <summary>
            /// Return unique Int64 value for input string
            /// </summary>
            /// <param name="strText"></param>
            /// <returns></returns>
            public static Int64 GetUniquetHashCode(this string strText)
            {
                Int64 hashCode = 0;
                if (!string.IsNullOrEmpty(strText))
                {
                    //Unicode Encode Covering all character-set
                    byte[] byteContents = Encoding.Unicode.GetBytes(strText);
                    System.Security.Cryptography.SHA256 hash =  new System.Security.Cryptography.SHA256CryptoServiceProvider();
                    byte[] hashText = hash.ComputeHash(byteContents);
                    //32Byte hashText separate
                    //hashCodeStart = 0~7  8Byte
                    //hashCodeMedium = 8~23  8Byte
                    //hashCodeEnd = 24~31  8Byte
                    //and Fold
                    Int64 hashCodeStart = BitConverter.ToInt64(hashText, 0);
                    Int64 hashCodeMedium = BitConverter.ToInt64(hashText, 8);
                    Int64 hashCodeEnd = BitConverter.ToInt64(hashText, 24);
                    hashCode = hashCodeStart ^ hashCodeMedium ^ hashCodeEnd;
                }
                return (hashCode);
            }
    
    
        }
