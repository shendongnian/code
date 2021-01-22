    class Data 
    {
        public string Prop1 {get; set;}
        public string Prop2 {get; set;}
    }
    
    class Dao<T>
    {
        SaveEntity<T>(T data)
        {
            // use reflection for saving your properies (this is what any ORM does for you)
        }
        IList<T> GetAll<T>()
        {
            // use reflection to retrieve all data of this type (again, ORM does this for you)
        }
    }
    
    // usage:
    Dao<Data> myDao = new Dao<Data>();
    List<Data> allData = myDao.GetAll();
    // modify, query etc using Dao, lazy evaluation and caching is done by the ORM for performance
    // but more importantly, this design keeps your code clean, readable and maintainable.
