    private static object ThisLock = new object();
    ...
    object dataObject = Cache["globalData"];
    if( dataObject == null )
    {
        lock( ThisLock )
        {
            dataObject = Cache["globalData"];
            if( dataObject == null )
            {
                //Get Data from db
                 dataObject = GlobalObj.GetData();
                 Cache["globalData"] = dataObject;
            }
        }
    }
    return dataObject;
