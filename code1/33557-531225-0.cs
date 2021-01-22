    class myclass
    {
    
    private static myclass singleobj = null;
    private myclass(){}
    public static myclass CreateInstance()
    {
    if(singleobj == null)
      singleobj =  new myclass();
    
    return singleobj
    }
    
    }
