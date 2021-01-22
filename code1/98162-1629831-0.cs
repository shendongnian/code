    MyClass obj = null;
    using (DataContext context = new DataContext())
    {
        context.ObjectTrackingEnabled = false;
        obj = (from p in context.MyClasses
                where p.ID == someId
                select p).FirstOrDefault();
    }
    
    obj.Name += "test";
    
    using (DataContext context2 = new ())
    {
        context2.MyClasses.Attach(obj);
        context2.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, obj);
        context2.SubmitChanges();
    }
