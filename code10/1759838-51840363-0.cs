    // singleton object of 
    public class ExcelDataContext
    {
        // creating an object of ExcelDataContext
        private static ExcelDataContext instance = new ExcelDataContext();
        // no instantiated available
        private ExcelDataContext()
        {
            FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
        
            DataSet result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });
            this.Sheets = result .Tables;
        }
        // accessing to ExcelDataContext singleton
        public static ExcelDataContext GetInstance()
        {
            return instance;
        }
        // the dataset of Excel
        public DataTableCollection Sheets { get; private set; }
    }
