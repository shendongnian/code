    public async Task A()
    {
        Debug.Log("before")
        await CopyInfoFromDB();
        Debug.Log("after") 
    }
    public async Task CopyInfoFromDB()
    {
          return FirebaseDatabase.DefaultInstance
                                 .GetReference(path)
                                 .GetValueAsync();
    }
