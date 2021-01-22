    class CustomRetVal {
        int CurrentIndex { get; set; }
        string Message { get; set; }
        int CurrentTotal { get; set; }
    }
    var retVal = GetSomething();
    //get % progress
    retVal.CurrentIndex / retVal.CurrentTotal;
