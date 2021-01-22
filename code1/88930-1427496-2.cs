    public class CollectionViewModel : ViewModelBase
    {          
        public ObservableCollection<EntityViewModel> ContentList
        {
            get { return _contentList; }
        }
    
        public CollectionViewModel()
        {
             _contentList = new ObservableCollection<EntityViewModel>();
             _contentList.CollectionChanged += ContentCollectionChanged;
        }
    
        public void ContentCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach(EntityViewModel item in e.NewItems)
                {
                    //Removed items
                    item.PropertyChanged -= EntityViewModelPropertyChanged;
                }
            }
            else if (e.Action = NotifyCollectionChangedAction.Add)
            {
                foreach(EntityViewModel item in e.NewItems)
                {
                    //Added items
                    item.PropertyChanged += EntityViewModelPropertyChanged;
                }     
            }       
        }
        public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
        }
    }
