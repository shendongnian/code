    public class CreateColumn
    {
        public void CreateColumns(CreateTable ct)
        {
            ct.AddColumn(typeof(Int32),"ID");
            ct.AddColumn(typeof(String),"Name");
            ct.AddColumn(typeof(String), "Address");
            ct.AddColumn(typeof(Int64),"Phone");
            ct.AddColumn(typeof(String),"Dept");
            ct.AddColumn(typeof(Decimal),"Salary");
        }
    }
