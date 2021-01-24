    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Invalid Argument");
                Console.WriteLine("Usage:");
                Console.WriteLine("\tExtractPublicKey [Input SNK File] [Output XML File]");
                return;
            }
            using (FileStream fs = File.Open(args[0], FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, bytes.Length);
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.ImportCspBlob(bytes);
                    using (StreamWriter sw = new StreamWriter(File.Open(args[1], FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)))
                        sw.Write(rsa.ToXmlString(false));
                }
            }
        }
    }
