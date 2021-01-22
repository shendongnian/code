    class ActionCommand
    {
        private readonly Action _action;
        public ActionCommand(Action action)
        {
            _action = action;
        }
        public override void Do()
        {
            _action();
        }                   
    };
