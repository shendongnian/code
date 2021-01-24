    public ActionResult Test(MyClass baseObj,int Counter){
        for(int i=0;i<Counter;i++) {
    
            MyClass newObject = new MyClass()
            {
                Name = baseObj.Name,
                Color = baseObj.Color
            };
    
            Db.MyClass.Add(NewObject);
            Db.SaveChanges();
        }
     }
