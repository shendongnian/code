    private Queue actions = new Queue();
    
    public void DoSomethingToHelper()
    {
       if(!helperClass.IsReady())
       {
          Action work = new Action(DoSomethingToComponent);
       }
       else
       {
           // Real work here.
       }
    }
