    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private object currentViewModel;
        public object CurrentViewModel
        {
            get { return currentViewModel; }
            set { currentViewModel = value; RaisePropertyChanged(); }
        }
        private RelayCommand<Type> navigateCommand;
        public RelayCommand<Type> NavigateCommand
        {
            get
            {
                return navigateCommand
                  ?? (navigateCommand = new RelayCommand<Type>(
                    vmType =>
                    {
                        CurrentViewModel = null;
                        CurrentViewModel = Activator.CreateInstance(vmType);
                    }));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
