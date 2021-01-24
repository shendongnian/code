    using System.IO;
            foreach (string file in Directory.GetFiles(path))
            {
                byte[] fileByte = File.ReadAllBytes(file);
                MD5 md5Hash = MD5.Create();        
                Console.WriteLine("The MD5 Hash of the file is; " + 
                      BitConverter.ToString(md5Hash.ComputeHash(fileByte))
                                  .Replace("-", string.Empty)
                                  .ToLower());        
            }
