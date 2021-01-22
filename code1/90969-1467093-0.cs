    class MyClass
    {
        private StreamReader sr;
        string invoiceNumberFunc()
        {
            if (sr == null) 
                sr = new StreamReader(path);
            if (sr.EndOfStream)  {
                sr.Close();
                sr = null;
                return string.Empty;
            }
            try {
                return sr.ReadLine();
            }
            catch(Exception exp) {
                Console.WriteLine("Process failed {0}",exp.ToString());
                return string.Empty;
            }
        }
    }
