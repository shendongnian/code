	using Prism.Mvvm;
	using Prism.Regions;
    public class DomePositioningViewModel : BindableBase, INavigationAware
    {
        ObservableCollection<PositioningModule> _positioningModuleCollection = new ObservableCollection<PositioningModule>();
        readonly object _lock = new object();
        DomePositioningModel _domePositioningModel = new DomePositioningModel();
        public DomePositioningViewModel()
        {
            BindingOperations.EnableCollectionSynchronization(_positioningModuleCollection, _lock);
        }
        public /* async */ void OnNavigatedTo(NavigationContext navigationContext)
        {
            //await _domePositioningModel.ScanForModulesAsync(AddModule); - this blocks the UI
            Task.Run(() => _domePositioningModel.ScanForModulesAsync(AddModule));
        }
        private void AddModule(PositioningModule module)
        {
            lock (_lock)
            {
                _positioningModuleCollection.Add(module);
            }
        }
    }
	
