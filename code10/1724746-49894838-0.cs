    public class MasterWindowViewModel : BaseViewModel
    {
        public bool IsPlaying { get; set; } = false;
        private string _playButtonText = "Play";
        public string PlayButtonText
        {
            get => _playButtonText;
            set => _playButtonText = value;
        }
        public ICommand StartStopCommand { get; set; }
        public MasterWindowViewModel()
        {
            StartStopCommand = new RelayCommand(() => StartStop());
        }
        private void StartStop()
        {
            IsPlaying = !IsPlaying;
            PlayButtonText = IsPlaying ? "Stop" : "Play";
            OnPropertyChanged("PlayButtonText");
        }
    }
