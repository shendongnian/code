    protected override bool OnBackButtonPressed()
    {
        var vm = (SignInViewModel)BindingContext;
        vm.GoBackCommand.Execute();
        return base.OnBackButtonPressed();
    }
