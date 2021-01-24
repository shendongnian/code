    public class ViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            public ICommand AddCommand { get; set; }
    
            public ViewModel()
            {
                AddCommand = new RelayCommand(AddCommandHandler);
    
            }
    
            private void AddCommandHandler()
            {
                IPopUpBanks popu = new PopUpBanks(this);
                popu.Show();
            }
        }
