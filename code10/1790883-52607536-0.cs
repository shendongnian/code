    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //building would take place in a factory method
            DataContext = new LongLivingModel();
            LongLivingModel.AddChild();
            LongLivingModel.AddChild();
        }
    }
    
    public class ShortLivedViewModel : INotifyPropertyChanged
    {
    	private readonly LongLivingModel longLivingModel;
    
    	public ShortLivedViewModel(LongLivingModel longLivingModel){
    		this.longLivingModel = longLivingModel;
    	}
    
        private string _myText;
    
        public string MyText
        {
            get => _myText;
            set
            {
                _myText = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(MyText)));
            }
        }
    
        public void Remove(){
        	longLivingModel.Remove(this);
        }
        // INotifyPropertyChanged implementation
    }
    
    public class LongLivingModel
    {
    	public ObservableCollection<ShortLivedViewModel> ChildViewModels { get; } = new ObservableCollection<ShortLivedViewModel>();
    
    	public void AddChild(){
    		ChildViewModels.Add(new ShortLivedViewModel(this));
    	}
    
    	public void RemoveChild(ShortLivedViewModel shortLivedViewModel) {
    		ChildViewModels.Remove(shortLivedViewModel);
    	}
    
    	public void PushToChildren(){
    		foreach(ShortLivedViewModel shortLivedViewModel in ChildViewModels){
    			shortLivedViewModel.MyText = Guid.NewGuid().ToString("N");
    		}
    	}
    }
