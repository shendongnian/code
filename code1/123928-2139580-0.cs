    class DefaultCommand:BaseCommand
    {
        //_canExecute is supposed protected Predicate<string> in base class
        public DefaultCommand()
        {
           base._canExecute =x=>x=="SomeExecutable";
        }
    }
