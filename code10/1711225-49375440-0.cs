    public class MainViewModel : ViewModelBase {
        public ObservableCollection<DockPaneViewModel> DockPanes { get; set; }
        //Give the view model only what it needs
        public MainViewModel(IEnumerable<DockPaneViewModel> panes) {
            DockPanes = new ObservableCollection<DockPaneViewModel>(panes);
        }
        public void ResetPanes() {
            foreach (var pane in DockPanes) {
                pane.Reset();
            }
            //notify view
        }
    }
    
