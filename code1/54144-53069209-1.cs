    public IMvxCommand MyCommand
            {
                get
                {
                    return new MvxCommand(() =>
                    {
                        var command = nameof(MyCommand);
                        if (IsCommandRunning(command)) return;
    
                        try
                        {
                            StartCommand(command);
    
                            //your code
                        }
                        finally
                        {
                            FinishCommand(command);
                        }
                    });
                }
            }
