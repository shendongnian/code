    using (var ut = new UpdateTransaction(myObject))
    // UpdateTransaction constructor calls myObject.BeginUpdate
    {
        myObject.MyProp = 5;
        // ...
    }
    // at the end of using clause Dispose is called,
    // which in turn calls myObject.FinishUpdate  
