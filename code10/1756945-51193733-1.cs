     public LogInViewController (IntPtr handle) : base (handle)
        {
            this.WhenActivated(d =>
            {
                d(this.Bind(ViewModel, vm => vm.UserName, vm => vm.userNameTextField.Text));
                d(this.Bind(ViewModel, vm => vm.Password, vm => vm.passwordTextField.Text));
                d(this.BindCommand(this.ViewModel,vm => vm.LoginCommand,v => v.LoginButton));
            });
        }
