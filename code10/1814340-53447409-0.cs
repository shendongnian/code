        RelayCommand _myCommand;
        public ICommand MyCommand
        {
            get
            {
                if (_myCommand== null)
                {
                    _myCommand= new RelayCommand(param =>
                    {
                        if(((Button)param).Name == "Button1"){
                              //Do what you wish to do with Button1 Click
                         }
                    });
                }
                return _myCommand;
            }
        }
