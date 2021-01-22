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
            //This will get called when the collection is changed
        }
    }
