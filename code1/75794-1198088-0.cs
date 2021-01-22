    class myObject
    {
       public Save()
       {
          myObjFactory.Save(this);
       }
    }
    ...
    
    class myObjectFactory
    {
       public void Save(myObject obj)
       {
          // Upsert myObject   
       }
    }
