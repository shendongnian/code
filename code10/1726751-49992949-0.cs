    using Prism.Mvvm;
    public class Ctrl
    {
        public int RGN_Index { get; set; }
        public string RGN { get; set; }
        public string RSN { get; set; }
        public string SGN { get; set; }
        public string SN { get; set; }
    }
    public class TheViewModel : BindableBase
    {
        public ObservableCollection<Ctrl> ListControls { get { return _listControls; } set { SetProperty(ref _listControls, value); } }
        private ObservableCollection<Ctrl> _listControls;
        // Constructor
        public class TheViewModel()
        {
            ListControls = new ObservableCollection<Ctrl>()
            {
                new Ctrl() {RGN_Index=1,RGN="RGN1", RSN="RSN1",SGN="SGN1",SN="SN1" },
                new Ctrl() {RGN_Index=2,RGN="RGN2", RSN="RSN2",SGN="SGN2",SN="SN2" }
            };
        }
 
    }
