    public class ViewModel : ViewModelBase {
        private readonly LocalMapService localMapService;
        private readonly Model myModel;
        private string serviceUri;
        public ViewModel() {
            myModel = new Model();
            localMapService = new LocalMapService(myModel.MapPackage);
            starting += onStarting;
            starting(this, EventArgs.Empty);
        }
        private event EventHandler starting = delegate { };
        private async void onStarting(object sender, EventArgs args) {
            starting -= onStarting; //optional
            
            // the following runs on background thread
            await localMapService.StartAsync(); 
            
            // returned to the UI thread
            ServiceUri = localMapService.UrlMapService; //notifies UI
        }
        public string ServiceUri {
            get { return serviceUri; }
            set {
                serviceUri = value;
                OnPropertyChanged();
            }
        }
    }
    
    public class ViewModelBase : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        
        protected void OnPropertyChanged([CallerMemberName] string member = "") {
            PropertyChanged(this, new PropertyChangedEventArgs(member));
        }
    }
    
