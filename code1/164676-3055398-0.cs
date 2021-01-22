    using(var datacontext=new DatesDataContext())
    {
        var myDate=DateTime.Today;
        //Or, to specify a date without string parsing
        //var myDate=new DateTime(2010,6,16);
        var dates = from date in datacontext.DateTables
            where date.DateField == myDate                 
            select date;
        datacontext.Log = Console.Out;
        foreach (var date in dates)
        {
            Console.WriteLine(date.DateField);
        }
    }
