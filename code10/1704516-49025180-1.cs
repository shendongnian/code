    class Command<T> : ICommand
    {
        public bool CanExecute(object param) =>
            this.CanExecute(param as T);
        public void Execute(object param) =>
            this.Execute(param as T);
        public bool CanExecute(T param) { ... }
        public void Execute(T param) { ... }
    }
