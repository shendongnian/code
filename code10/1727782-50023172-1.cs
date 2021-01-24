    class MyClass{ 
        public int Id { set; get; }
        public string Name { set; get; }
        public string Color { set; get; }
        public MyClass Clone() {
            MyClass clone = (MyClass)MemberwiseClone();
            clone.Id = 0;
            return clone;
        }
    }
    
    public ActionResult Test(MyClass obj, int Counter){
        for(int i = 0; i < Counter; i++){
            MyClass newObject = obj.Clone();
            newObject.Name = obj.Name + " " + i.ToString();
            Db.MyClass.Add(newObject);
            Db.SaveChanges();
        }
    }
