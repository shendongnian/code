    this.WhenActivated(disposables =>
            {
                
                this.OneWayBind(ViewModel, vm => vm.UserRole,
                    v => v.UserRole.Text, GetAbreviatedRole).DisposeWith(disposables);
            });
