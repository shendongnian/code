       private _Example_Items;
       public List<string> Example_Items
        {
            get 
            { 
                if(_Example_Items == null)
                {
                    loadExampleItems();
                }
    
                return _Example_Items; 
            }
            set
            {
                _Example_Items = value;
                OnPropertyChanged("Example_Items");
            }
        }
