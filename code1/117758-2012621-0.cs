    public static string MD5(string originalPassword)
            {
                Byte[] originalBytes;
                Byte[] encodedBytes;
                MD5 md5;
    
                //Instantiate MD5CryptoServiceProvider, 
                //get bytes for original password and compute hash (encoded password)
                md5 = new MD5CryptoServiceProvider();
                originalBytes = ASCIIEncoding.Default.GetBytes(originalPassword);
                encodedBytes = md5.ComputeHash(originalBytes);
    
                //Convert encoded bytes back to a 'readable' string
                return BitConverter.ToString(encodedBytes);
            }
