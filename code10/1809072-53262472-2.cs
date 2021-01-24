     private static string GetChecksum(string s)
            {//this gives matching checksums
                int checksum = 0;
    
                byte[] binary = Encoding.ASCII.GetBytes(s);
    
                foreach (byte b in binary)
                {
                    checksum = ((checksum + b));
                }
                return checksum.ToString("X4");
            }
