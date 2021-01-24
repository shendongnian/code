            public ICommand ButtonCommand
            {
                get
                {
                    if (_buttonCommand == null)
                    {
                        _buttonCommand = new RelayCommand<string>(CommandExecute, CanCommandExecute);
                    }
                    return _buttonCommand;
                }
            }
