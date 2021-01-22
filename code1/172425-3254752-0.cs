    private ICommand _getDataCommand;
    public ICommand GetDataCommand
        {
            get
            {
                if (this._getDataCommand == null)
                {
                    this._getDataCommand = new RelayCommand(param => this.GetMyData(), param => true);
                }
                
                return this._getDataCommand;
            }
        }
   
    private void GetMyData{
    //go and get data from Model and add to the MyControls collection
    }
     private ObservableCollection<MyUserControls> _uc; 
     public ObservableCollection<MyUserControls> MyControls
                {
                    get
                    {
                        if (this._uc == null)
                        {
                            this._uc = new ObservableCollection<MyUserControls>();
                        }
                        return this._uc;
                    }
                }
