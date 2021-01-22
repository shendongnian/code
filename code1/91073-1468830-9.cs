    public class MyViewModel
    {
        private ICommand _doSomething;
        public ICommand DoSomethingCommand
        {
            get
            {
                if (_doSomething == null)
                {
                    _doSomething = new RelayCommand(
                        p => this.CanDoSomething,
                        p => this.DoSomeImportantMethod());
                }
                return _doSomething;
            }
        }
    }
