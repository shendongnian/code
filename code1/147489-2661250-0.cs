    public void DoSomethingWithText(string text)
    {
        if (string.IsNullOrEmpty(text))
            throw new ArgumentException("Cannot be null or empty.", "text");
        ThreadPool.QueueUserWorkItem(o => // Lambda
            {
                try
                {
                    // text is captured in a closure so you can manipulate it.
                    var length = text.Length; 
    
                    // Do something else with text ...
                }
                catch (Exception ex)
                {
                    // You probably want to handle this somehow.
                }
            }
        );
    }
