     public class MyApplication : Application
    {
    public MyApplication() : base(handle, ownerShip) //here's the editing location
    {
    }
    public override void OnCreate()
    {
        base.OnCreate();
        getDataFromDB();
    }
    public void getDataFromDB()
    { // code
    }
    }
