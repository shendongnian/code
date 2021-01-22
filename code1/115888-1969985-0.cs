       using (FileStream stream = File.OpenRead(@"C:\File.ext"))
                {
                    SHA1Managed sha = new SHA1Managed();
                    byte [] checksum = sha.ComputeHash(stream);
                    string sendCheckSum = BitConverter.ToString(checksum).Replace("-", string.Empty);
    
                }
