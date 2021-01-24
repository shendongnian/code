    private bool _isClosing = false;
    public FooWindow()
    {
       Closing += (x, y) => {
           _isClosing = true;
           Exit(); 
       };
    }
    
    private void Exit()
    {
       if (someVariable)
       {
           Environment.Exit(1);
       }
       else
       {
          if (!_isClosing) Close(); 
       }
    
    }
