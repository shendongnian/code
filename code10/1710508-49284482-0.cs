    public ICommand ExecuteCommand
        {
            get
            {
                if (_command == null)
                {
                    _command = new RelayCommand(param => this.NextQuestion());
                }
                return _command;
            }
        }
        public void NextQuestion()
        {
            //Do Stuff Here
        }
