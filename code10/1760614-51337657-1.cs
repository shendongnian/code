    private ObservableCollection<string> comboBoxItemsource;
     public ObservableCollection<string> ComboBoxItemsource
            {
                get { return comboBoxItemsource; }
                set
                {
                    if (comboBoxItemsource != value)
                    {
                        comboBoxItemsource = value; 
                        RaisePropertyChanged("ComboBoxItemsource");
                    }
                }
            }
        
        In Class Constructor-
    
    public ClassViewModel()
            {
                ComboBoxItemsource = new ObservableCollection<string>();
                ComboBoxItemsource.Add("Item1");
                ComboBoxItemsource.Add("Item2");
               ....
           }
    
        //Event on which you want to change the collection
    
        public void OnClickEvent()
        {
                    ComboBoxItemsource = new ObservableCollection<string>();
                    ComboBoxItemsource.Add("Item5");
                    ComboBoxItemsource.Add("Item6");
        }
