    public class MoneyPageViewModel: INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            private ICommand _readAdminVersions;
            public ICommand readAdminVersions
            {
                get
                {
                    return _readAdminVersions ??
                           (_readAdminVersions = new 
                            RelayCommandAsync(executeReadAdminVersions, (c) => true));
                }
            }
            private async Task executeReadAdminVersions()
            {//your code here
            }
        }  
