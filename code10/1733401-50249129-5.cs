        private ICommand _RbChecked;
        public ICommand RbChecked
        {
            get { return _RbChecked ?? (_RbChecked = new RelayCommand<object>(a => RbCheckedCommand(a))); }
        }
        private void RbCheckedCommand(object item)
        {
            this.CurrentChosen = (string)item;
        }
