    class MainWindowViewModel : Conductor<IScreen>.Collection.OneActive, IHandle<OnLoginSuccessMessage>
    {
    
            public void Handle(OnLoginSuccessMessage message)
            {
                if(message.IsLoginSuccessful)
                {
                    // Login is successfull, do next steps.
                }
            } 
    }
