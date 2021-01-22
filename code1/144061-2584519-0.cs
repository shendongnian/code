    var date = _b.GetSomeDate(SomeID);
    MyTestViewModel asdf = new MyTestViewModel 
    {
        SomeTestDate = date.HasValue ? date.Value : DateTime.MinValue,
        SomeDate2 = SomeDate2.Value,
        SomeDate3 = SomeDate3.Value
    };
