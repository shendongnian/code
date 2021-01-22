    public class TableRepository
        {
            string connstr;
    
            public TableRepository() 
            {
                connstr = Settings.Default.YourTableConnectionString.ToString();
            }
    
            public List<YourTable> GetAllDataByID(int ID)
            {
                List<YourTable> table= new List<YourTable>();
                using (YourTableDBDataContext dc = new YourTableDBDataContext ())
                {
                    table= dc.GetAllDataByID(CID).ToList();
                }
                return table;
            }
        }
