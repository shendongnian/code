    public class YourNewClass : IYourNewClass
    {    
        private CustomSqlConnection _connection { get; set; }
        //inject IOption here
        public YourNewClass(IOptions<MyConfig> _config)
        {
           _connection = new CustomSqlConnection(_config); //use this instance for all the repository methods
        }
    }
