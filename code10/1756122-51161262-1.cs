    class Program
    {
        private string fileName = "myFile.xml";
        private string sourcePath = @"d:\source\" + fileName;        
        private string destinationPath = @"d:\destination\" + fileName;
        
        static void Main(string[] args)
        {           
            (new Program()).Run();
        }
        void Run()
        {
            PrepareSourceFile();
            CopyFile();
        }
        private void PrepareSourceFile()
        {
            DataTable helloWorldData = new DataTable("HelloWorld");            
            helloWorldData.Columns.Add(new DataColumn("Greetings"));
            DataRow dr = helloWorldData.NewRow();
            dr["Greetings"] = "Ola!";
            helloWorldData.Rows.Add(dr);
            helloWorldData.WriteXml(sourcePath);
        }
        private void CopyFile()
        {
            int numberOfRetries = 3; // I want to retry at least these many times before giving up.
            do
            {   
                try
                {
                    File.Copy(sourcePath, destinationPath, true);
                }
                finally
                {
                    if (CompareChecksum())
                        numberOfRetries = 0;
                }
                
                
            } while (numberOfRetries > 0);
        }
        private bool CompareChecksum()
        {
            bool doesChecksumMatch = false;
            if (GetChecksum(sourcePath) == GetChecksum(destinationPath))
                doesChecksumMatch = true;
            return doesChecksumMatch;
        }
        private string GetChecksum(string file)
        {
            using (FileStream stream = File.OpenRead(file))
            {
                SHA256Managed sha = new SHA256Managed();
                byte[] checksum = sha.ComputeHash(stream);
                return BitConverter.ToString(checksum).Replace("-", String.Empty);
            }
        }
    }
