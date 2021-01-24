    public interface IGetsSomeData
    {
        Data GetSomeData();
    }
    public class GetsSomeDataFromAFile : IGetsSomeData
    {
        private readonly IFilePathSettings _filePathSettings;
        public GetsSomeDataFromAFile(IFilePathSettings filePathSettings)
        {
            _filePathSettings = filePathSettings;
        }
        public DataGetSomeData()
        {
            // read data from a file using a file path
        }
    }
    public class GetsSomeDataFromSql : IGetsSomeData
    {
        private readonly IDatabaseSettings _databaseSettings;
        public GetsSomeDataFromAFile(IDatabaseSettings databaseSettings)
        {
            _databaseSettings = databaseSettings;
        }
        public DataGetSomeData()
        {
            // execute a SQL query using a connection string
        }
    }
