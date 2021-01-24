     public void TestMethod(object obj) 
     {
        Cat cat = obj as cat;
        if(cat != null)
        { 
           
            return;
        }
        ICollection<Cat> cats = obj as ICollection<Cat>;
        if(cats != null)
        {
 
        }
     }
