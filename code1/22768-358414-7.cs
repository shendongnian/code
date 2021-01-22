    public interface IFoo
    {
         int Number { get; }|
    }
    public class FooWithName : IFoo
    {
         private string tableName;
         public FooWithName( string name )
         {
             this.tableName = name;
         }
         public int Number
         {
            get { return this.RunTableInfoCommand(this.tableName,
                                           TableInfoEnum.TAB_INFO_NUM);
         }
         ... rest of class, including RunTableInfoCommand(string,int);
    }
    public class FooWithNumber : IFoo
    {
         private int tableNumber;
         public FooWithNumber( int number )
         {
             this.tableNumber = number;
         }
         public int Number
         {
            get { return this.RunTableInfoCommand(this.tableNumber,
                                           TableInfoEnum.TAB_INFO_NUM);
         }
         ... rest of class, including RunTableInfoCommand(int,int);
    }
