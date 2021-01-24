    private string task1Name = "task1";
    private string task2Name = "task2";
    _task1 = FuncA(task1Name );
    _task2 = FuncA(task2Name );
    
    public async Task FuncA(sting taskName)
    {
      // do something
      await Task.Delay(500, CancellationToken.None).ConfigureAwait(false);
    
      // then call the other function
      await FuncB(taskName).ConfigureAwait(false);
    }
    
    public async Task FuncB(string parentName)
    {
      // now check for the 'parent'
      if( parentName == task1Name ) // <--- something similar 
      {
        // child of first task
      }
    }
