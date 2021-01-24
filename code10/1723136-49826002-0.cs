    public class CsvRepository : IRepository<IBasic>
        {
    
            private string _path;
    
            public CsvRepository()
            {
                var filename = ConfigurationManager.AppSettings["CSVFileName"];
                _path = AppDomain.CurrentDomain.BaseDirectory + filename;
            }
    
            public IEnumerable<IBasic> GetRecords()
            {
                _path = "Read path";
                //Implement Yield & iterator here !!
                throw new NotImplementedException();
            }
        }
    
        //other repositories:
        public class OracleRepository : IRepository<IBasic>
        {
    
            private string _path;
    
            public OracleRepository()
            {
                var filename = ConfigurationManager.AppSettings["CSVFileName"];
                _path = AppDomain.CurrentDomain.BaseDirectory + filename;
            }
    
            public IEnumerable<IBasic> GetRecords()
            {
                _path = "Read path";
                //Implement Yield & iterator here !!
                throw new NotImplementedException();
            }
        }
