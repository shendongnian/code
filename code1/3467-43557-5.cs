    [System.Data.Linq.Mapping.DatabaseAttribute(Name="MyDB")]
    public partial class MyDataContext : System.Data.Linq.DataContext
    {
        ...
		
        partial void OnCreated();
        partial void InsertMyTable(MyTable instance);
        partial void UpdateMyTable(MyTable instance);
        partial void DeleteMyTable(MyTable instance);
    
        ...
