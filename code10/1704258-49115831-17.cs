     private RelayCommand _updateItemSourceCommand;
        public RelayCommand UpdateItemSourceCommand
        {
            get
            {
                return _updateItemSourceCommand
                       ?? (_updateItemSourceCommand = new RelayCommand(
                           () =>
                           {
                               //Update your DataGridCollection, you could also pass a parameter and use it.
                               //Update your DataGridCollection based on DataGridColumnsModel.HeaderPropertyCollection
                           }));
            }
        }
