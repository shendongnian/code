    using System.Data;  
    using ExcelWriter;
    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataSet ds = clsExcelWriter.OpenFile(@"C:\Results.xls");
                // Do some fancy stuff with the DataSet! xD
  
                while (true) ;
            }
        }
    }
