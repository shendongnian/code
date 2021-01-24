        static void Main(string[] args)
        {
            using (ZipFile zip = ZipFile.Read(@"d:\test.zip"))
            {
                foreach (ZipEntry e in zip)
                {
                    Console.WriteLine(e.IsDirectory);
                }
            }
        }
