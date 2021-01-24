    public class NotifiableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propName = null)
        {
            if (!string.IsNullOrWhiteSpace(propName))
            {
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
                }));
            }
        }
    }
