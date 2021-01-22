    int[] arr1 = { 1, 23, 57, 59, 120 };
    int maxResult;
    string errorMsg;
    try
    {
        maxResult = arr1.Where(x => x <= 109).Max();
    }
    catch(Exception e)
    {
        errorMsg = e.Message;
        // do some error stuff here :)
        return null;
    }
    // party on your maxResult...
