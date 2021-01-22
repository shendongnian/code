    using System.Text;
    
    class Test
    {
        static void Main()
        {
            using (MD5 md5 = MD5.Create())
            using (SHA1 sha1 = SHA1.Create())
            using (Stream input = File.OpenRead("b.txt"))
            {
                // Artificially small to make sure there's
                // more than one read
                byte[] buffer = new byte[4];
                int bytesRead;
                            
                while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    md5.TransformBlock(buffer, 0, bytesRead, null, 0);
                    sha1.TransformBlock(buffer, 0, bytesRead, null, 0);
                }
                md5.TransformFinalBlock(buffer, 0, 0);
                sha1.TransformFinalBlock(buffer, 0, 0);
                
                Console.WriteLine(BitConverter.ToString(md5.Hash));
                Console.WriteLine(BitConverter.ToString(sha1.Hash));
            }
        }
    }
