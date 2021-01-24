    public static MyObj GetMyObj(long id)
    {
        using (MyDataContext dc = new MyDataDataContext("connectionstring"))
        {
            dc.ObjectTrackingEnabled = false;
            DataLoadOptions load = new DataLoadOptions();
            load.LoadWith<MyObj>(d => d.MyMember);
            dc.LoadOptions = load; //<-- New line
            return dc.MyObjs.FirstOrDefault(x => x.ID == id);
        }
    }
    var myObj = GetMyObj(10);
    var test = myObj.MyMember.Count(); // MyMember is null which it shouldn't be
