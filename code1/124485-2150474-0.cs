        using System.Security.Cryptography;
        public string HashFile(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                return HashFile(fs);
            }
        }
        public string HashFile( FileStream stream )
        {
            StringBuilder sb = new StringBuilder();
            if( stream != null )
            {
                stream.Seek( 0, SeekOrigin.Begin );
                MD5 md5 = MD5CryptoServiceProvider.Create();
                byte[] hash = md5.ComputeHash( stream );
                foreach( byte b in hash )
                    sb.Append( b.ToString( "x2" ) );
                stream.Seek( 0, SeekOrigin.Begin );
            }
            return sb.ToString();
        }
