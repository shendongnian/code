    static void Main(string[] args)
    {
        var Customer = new { FirstName = "John", LastName = "Doe" };
        var customerList = MakeList(Customer);
        
        customerList.Add(new { FirstName = "Bill", LastName = "Smith" });
        //then you can bind this collection
        gridView.DataSource = customerList;
        gridVeew.DataBind();
    }
    public static List<T> MakeList<T>(T itemOftype)
    {
        List<T> newList = new List<T>();
        return newList;
    }      
  
