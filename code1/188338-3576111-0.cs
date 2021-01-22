    using GenericParsing;
    using System.Data;
    
    namespace CsvToDataTable
    {
        public class Program
        {
            static void Main(string[] args)
            {
                var pathOfCsvFile = @"C:\MyFile.csv";
                var adapter = new GenericParsing.GenericParserAdapter(pathOfCsvFile);
                DataTable data = adapter.GetDataTable();
            }
        }
    }
