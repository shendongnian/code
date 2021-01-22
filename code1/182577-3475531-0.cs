	private void InitializeBackgroundWorker()
	{
		_Worker = new BackgroundWorker();
                //On a call cast the e.Argument to a Func<TResult> and call it...
                //Take the result from it and put it into e.Result
		_Worker.DoWork += (sender, e) => e.Result = ((Func<string>)e.Argument)();
                //Take the e.Result and print it out
                (cause we will always call a Func<string> the e.Result must always be a string)
		_Worker.RunWorkerCompleted += (sender, e) =>
		{
			Debug.Print((string)e.Result);
		};
	}
    private void StartTheWorker()
    {
        int someValue = 42;
        //Take a method with a parameter and put it into another func with no parameter
        //This is called currying or binding
        _Worker.RunWorkerAsync(new Func<string>(() => DoSomething(someValue)));
       while(_Worker.IsBusy)
           Thread.Sleep(1);
       //If your function exactly matches, just put it into the argument.
       _Worker.RunWorkerAsync(AnotherTask);
    }
    private string DoSomething(int value)
    {
        return value.ToString("x");
    }
    private string AnotherTask()
    {
        return "Hello World";
    }
