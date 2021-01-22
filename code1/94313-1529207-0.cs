    public class SomeClass
    {
        public List<int> CategoryIDList { get; private set; }
    
        public void UpdateToDatabase()
        {
            string categoryIdList = ConvertIntListToString(this.CategoryIDList);
            // TODO Update Database.
        }
    
        private static string ConvertIntListToString(List<int> intList)
        {
            return string.Join(",", intList.Cast<string>().ToArray());
        }
    }
