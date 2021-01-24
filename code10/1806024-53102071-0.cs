    public sealed class GeneralOptionsViewModel : ViewModelBase
    {
        private static readonly GeneralOptionsViewModel _instance = new GeneralOptionsViewModel();
        private GeneralOptionsViewModel()
        {
            GetAvailableCameraList();
            DetectorTypeList = new List<string>() { "Cascade Detector" };
            SelectedDetectorTypeIndex = 0;
        }
        public static GeneralOptionsViewModel Instance => _instance;
        //...
    }
