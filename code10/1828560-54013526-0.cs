    public class ViewModel : INotifyPropertyChanged
    {
        private string name
        public string Name {
            get {return name;}
            set {
                   name = value;
                   PropertyChanged("Name");
            }
        public ICommand GetNameAsync;
        private void PropertyChanged(string prop)
        {
           if( PropertyChanged != null )
           {
              PropertyChanged(this, new PropertyChangedEventArgs(prop);
           }
        }
        public ViewModel()
        {
             Name="Loading...";
             GetNameAsync =  new AsyncCommand(async () => {Name = await GetNameAsync()});
        }
    
        private async Task<string> GetNameAsync()
        {
            await nameService.getName();
        }
    }
