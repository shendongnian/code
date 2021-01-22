    //Add other interfaces as needed
    public interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; }
    }
    public partial class DataSet1
    {
        partial class PersonTableDataTable
        {
        }
        partial class PersonTableRow : IPerson
        {
        }
    }
