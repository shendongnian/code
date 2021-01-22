    private void DoOperations(Action action)
    {
      action();
    }    
    //usage    
    DoAction( new Action(SayHello)  );
    private void SayHello()
    {
      Console.WriteLine("Hello World")
    }
