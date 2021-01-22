    //include namespace
    using Microsoft.Practices.Composite.Wpf.Commands;
    readonly List<Movies> _m;
        public ICommand TestCommand { get; set; }
        public MovieViewModel(List<Movies> m)
        {
            this.TestCommand = new DelegateCommand<object>(TestcommandHandler);
            _m = m;
        }
        public List<Movies> lm
        {
            get
            {
                return _m;
            }
        }
    void TestcommandHandler(object obj)
    {
          // add your logic here
    }
    }
