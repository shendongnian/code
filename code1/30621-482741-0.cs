    Array values = Enum.GetValues(typeof(myEnum));
    
    foreach( MyEnum val in values )
    {
       Console.WriteLine (String.Format("{0}: {1}", Enum.GetName(typeof(MyEnum), val), val);
    }
