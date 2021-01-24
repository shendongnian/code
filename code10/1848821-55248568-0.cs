    public class Tables
    {
        private readonly IDictionary<string, List<ShortRef_Control>> tableDictionary = new Dictionary<string, List<ShortRef_Control>>();
        
        public List<ShortRef_Control> this[string tableName]
        {
            get
            {
                if (ShouldReload(tableName))
                    Reload(tableName);
                return tableDictionary[tableName];
            }
        }
        public void Reload()
        {
            foreach (var tableName in tableDictionary.Keys)
                Reload(tableName);
        }
        private void Reload(string tableName)
        {
            // implement table-specific loading logic here:
            switch (tableName)
            {
                case "refcontrols":
                {
                    tableDictionary[tableName] = (from src in dataContext.ShortRef_Controls select src).ToList();
                    break;
                }
                default:
                {
                    throw new NotSupportedException($"invalid table name: {tableName}");
                }
            }
            
            // note: in the real world I wouldn't use a switch statement to implement the logic, but this is just to 
            // illustrate the general concept
        }
        private bool ShouldReload(string tableName)
        {
            return tableDictionary[tableName] == null || !tableDictionary[tableName].Any();
        }
    }
    
    
    public class TestClass
    {
        private readonly Tables tables = new Tables();
        public TestClass()
        {
            tables.Reload();
        }
        // this indexer will allow you to access your various tables from outside this class by specifying the table name
        public List<ShortRef_Control> this[string name]
        {
            get { return tables[name]; }
        }
        
        // if you need your table names hard-coded, you can create separate properties for each one:
        public List<ShortRef_Control> RefControlsTable { get { return this["refcontrols"]; }}
        
        // here's a few examples of how the tables would be accessed or used
        public void UseTableRefControl()
        {
            UseTableRefControl(DoSomethingWithRecord);
        }
        
        public void UseTableRefControl(Action<ShortRef_Control> action)
        {
            TakeActionOnTable("refcontrols", DoSomethingWithRecord);
        }
        public void TakeActionOnTable(string tableName, Action<ShortRef_Control> action)
        {
            foreach (var row in tables[tableName])
                action(row);
        }
        
        private static void DoSomethingWithRecord(ShortRef_Control row)
        {
            // do something with the row here
        }
    }
