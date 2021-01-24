    public ColorConsumer(dynamic color)
    {
       InstanceColor = HandleEnum(color);
    }
    // ...
    //then we update HandleEnum very slightly
    public object HandleEnum(object e)
    {
      int x = (int) e + 1;
      return Enum.ToObject(typeof(C), x);
    }
    
