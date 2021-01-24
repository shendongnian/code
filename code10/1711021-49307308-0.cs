    public RelayCommand<KeyEventArgs> KeyDownAction
        {
            get { return new RelayCommand<KeyEventArgs>(KeyDownMethod); }
        }
    
        private void KeyDownMethod(KeyEventArgs e)
        {
            //some code here 
        }
