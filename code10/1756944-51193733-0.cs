    public ReactiveCommand<Unit,Unit> LoginCommand { get; set; }
        public LoginViewModel()
        {
            //this operator does the magic, when UserName and Password be different than empty your button
            //will be enabled
            var canLogin = this.WhenAnyValue(x => x.UserName, x=> x.Password, 
                                            (user,password) => !string.IsNullOrWhiteSpace(user) && !string.IsNullOrWhiteSpace(password));
            LoginCommand = ReactiveCommand.CreateFromTask<Unit, Unit>(async _ =>
            {
                //Your login logic goes here..
                return Unit.Default;
            }, canLogin);
        }
