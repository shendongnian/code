    MyClass CreateInstance() {
        return new MyClass {
            Name = "theName";
            Color = "Red";
        }
    }
    
    public ActionResult Test(MyClass obj, int Counter){
        for(int i = 0; i < Counter; i++){
            MyClass newObject = CreateInstance();
            newObject.Name = newObject.Name + " " + i.ToString();
            Db.MyClass.Add(newObject);
            Db.SaveChanges();
        }
    }
