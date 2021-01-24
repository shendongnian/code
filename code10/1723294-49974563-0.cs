       private ObservableCollection<int> _intList;
       public ObservableCollection<int> IntList
         {
            get
            {
              return _intList;
            }
            set
            {
               _intList= value;
               _intList.CollectionChanged += 
                            new System.Collections.Specialized.NotifyCollectionChangedEventHandler
                                                (MyProperty_CollectionChanged);
                }
            } 
    
    void MyProperty_CollectionChanged(object sender,                        
             System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
      {
         NotifyPropertyChanged("IntList");
     }
