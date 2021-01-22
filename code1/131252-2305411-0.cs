    interface ICommand
    {
        void Execute();
    }
    
    class SomeCommand : ICommand
    {
        public SomeCommand(/* instance and parameters go here */) { /* ... */ }
    
        public void Execute() { /* ... */ }
    }
    class SomeOtherCommand : ICommand { /* ... */ }
