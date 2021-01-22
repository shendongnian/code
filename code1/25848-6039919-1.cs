    public LoginResult : IResult {
        // Constructor to set private members...
        
        public void Execute(ActionExecutionContext context) {
            wsClient.LoginCompleted += (sender, e) => {
                this.Success = e.Result;
                Completed(this, new ResultCompletionEventArgs());
            };
            wsClient.Login(username, password);
        }
        
        public event EventHandler<ResultCompletionEventArgs> Completed = delegate { };
        public bool Success { get; private set; }
    }
