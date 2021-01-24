    public class ViewModel
    {
        private ISomeService _someService;
        //note: someService is passed through a IoC service like ninject, unity, autofac etc.
        public ViewModel(ISomeService someService)
        {
            _someService = someService;
            //initialize the command:
            command = new RelayCommand(() =>
            {    
                _someService .SomeFancyMethod(new Model()
                {
                    //properties could be mapped with an automapper.
                });
            });
        }
        public ICommand command {get; private set;}
        public string Input {get; set;}
        public string Output {get; set;}
     }
