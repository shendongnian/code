    public class MyClass
    {
       private string _name;
    
       public string Name
       {
          get{ return _name; }
          set { _name = value; }
       }
       public string TestProperty
       {
          { get { return "Sample"; }
       }
    }
    
    ...
    [inside some form that contains your DataGridView class]
    
    MyClass c = new MyClass();
    
    // setting the data source will generate a column for "Name" and "TestProperty"
    dataGridView1.DataSource = c;
    // to remove specific columns from the DataGridView
    // dataGridView1.Columns.Remove("TestProperty")
