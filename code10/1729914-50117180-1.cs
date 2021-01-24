    public class MyViewModel : BaseViewModel, INotifyPropertyChanged
    {
    	public IMvxCommand RemoveItemCommand { get; private set; }
    	public MyViewModel()
    	{
    		// Initializing Commands
    		RemoveItemCommand = new MvxCommand<ItemClass>(OnRemoveItemClick);
    	}
    
    	public void OnRemoveItemClick(ItemClass anItem)
    	{
    		// Do stuff...
    	}
    	
    	private static ObservableCollection<ItemClass> _MyItemList = new ObservableCollection<ItemClass> {
            new ItemClass(),
            new ItemClass()
        };
    
        public ObservableCollection<ItemClass> MyItemList
        {
            get { return _MyItemList; }
        }
    }
