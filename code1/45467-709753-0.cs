        public class Category
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private string _Name = null;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public Category()
        {}
        public static List<Category> GetCategories()
        {
            List<Category> currentCategories = new List<Category>();
    
            DbCommand comm = GenericDataAccess.CreateTextCommand();
            comm.CommandText = "SELECT Id, Name FROM Categories Order By Name";
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            foreach (DataRow row in table.Rows)
            {
                Category cat = new Category();
                cat.Id = int.Parse(row["Id"].ToString());
                cat.Name = row["Name"].ToString();
                currentCategories.Add(cat);
            }
            return currentCategories;
        }
    }
