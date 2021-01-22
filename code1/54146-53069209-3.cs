    public IMvxCommand MyCommand
            {
                get
                {
                    return new MvxCommand(async() =>
                    {
                        var command = nameof(MyCommand);
                        if (IsCommandRunning(command)) return;
    
                        try
                        {
                            StartCommand(command);
    
                            await Task.Delay(3000);
                           //click the button several times while delay
                        }
                        finally
                        {
                            FinishCommand(command);
                        }
                    });
                }
            }
