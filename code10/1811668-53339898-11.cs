    public LoginViewModel(ILoginCommand loginCommand):base(loginCommand) { }
    protected override void RegisterCommands()
    {
        var command = (ILoginCommand)Commands[typeof(ILoginCommand)];
        command?
            .Configure(
                execute: (msg) => { Login(User); },
                canExecute: (x) => { return CanLogin(); }
                );
    }
