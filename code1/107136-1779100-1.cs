    public void DoSomethingThatTakesAgesAndNeedsToUpdateUiWhenFinished()
    {
        DisableUi();
        m_commandExecutor.ExecuteWithContinuation(
                    () =>
                        {
                            // this is the long-running bit
                            ConnectToServer();
        
                            // This is the continuation that will be run
                            // on the UI thread
                            return () =>
                                        {
                                            EnableUi();
                                        };
                        });
    }
