        private RelayCommand<Type> navigateCommand;
        public RelayCommand<Type> NavigateCommand
        {
            get
            {
                return navigateCommand
                  ?? (navigateCommand = new RelayCommand<Type>(
                    vmType =>
                    {
                        CurrentViewModel = null;
                        CurrentViewModel = Activator.CreateInstance(vmType);
                    }));
            }
        }
