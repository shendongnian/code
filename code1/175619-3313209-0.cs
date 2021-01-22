    class Foo1
    {
       public int Id { get; private set; }
       public Foo1()
       {
           Id = lastId ++;
       }
    }
    class Foo2
    {
       private int _id;  // could be readonly 
       public int Id { get { return _id; } }
       public Foo2()
       {
           _id = lastId ++;
       }
    }
