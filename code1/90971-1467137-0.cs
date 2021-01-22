        IEnumerable<String> invoiceNumberFunc()
        {
            string path = @"C:\Users\sam\Documents\GCProg\testReadFile.txt";
            try
            {
                using ( System.IO.StreamReader sr = new System.IO.StreamReader( path ) )
                {
                    String invoiceNumber;
                    while ( ( invoiceNumber = sr.ReadLine() ) != null )
                    {
                        yield return sr.ReadLine();
                    }
                }
            }
            finally
            {
            }
        }
