    class Program
    {
        static void Main()
        {
            string fileName = @"C:\Temp\sample.xml";
            DataSet ds = new DataSet();
            ds.ReadXml(fileName);
    
            Console.WriteLine(ds.Tables.Count);
            Console.WriteLine(ds.Tables[0].TableName);
            Console.WriteLine(ds.Tables[1].TableName);
            
            Console.Read();
        }
    }
