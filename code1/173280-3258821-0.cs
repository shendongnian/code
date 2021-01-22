    public Repository ObjRepository { get; set;}
    public void doStuff()
    {
       var obj = new object();
       doStuff(obj);
    }
    public void doStuff(Object obj)
    {
       ObjRepository.Save(obj)
    }
