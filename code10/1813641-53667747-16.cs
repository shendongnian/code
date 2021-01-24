    public class ViewModel : ViewModelBase {
        private readonly LocalMapService localMapService;
        private readonly Model myModel;
        private LayerCollection layers;
        public ViewModel() {
            myModel = new Model();
            layers = new LayerCollection();
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
            
            var serviceLayer = new ArcGISDynamicMapServiceLayer() {
                ID = "mpklayer",
                ServiceUri = localMapService.UrlMapService,
            };
            
            Layers.Add(serviceLayer);
            OnPropertyChanged(nameof(Layers)); //Notify UI
        }
        
        public LayerCollection Layers {
            get {
                return layers;
            }
        }
    }
    
