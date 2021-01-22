     ICommand _myButtonCommand;
        public ICommand MyButtonCommand
        {
            get 
            { 
                if (_myButtonCommand== null) _myButtonCommand = new RelayCommand(param => HideList(param ));  
                return _myButtonCommand;
            }
        }
        void HideList( object param )
        {
            ( param as ListView ).Visibility = Visibility.Hidden;
        }
