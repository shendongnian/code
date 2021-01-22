    // this could also be an instance method on the data-context
    internal static IQueryable<SomeType> MyFunc(
        this MyDataContext dc, parameter a)
    {
       return dc.tablename.Where(row => row.parameter == a);
    }
    private void UsingFunc()
    {
        using(MyDataContext dc = new MyDataContext()) {
           var result = dc.MyFunc(new a());
           foreach(var row in result)
           {
               //Do something
           }
        }
    }
