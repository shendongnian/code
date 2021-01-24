    namespace myproject.ViewModels    
    {
      public class projectViewModel : INotifyPropertyChanged
      {
        private ObservableCollection<projectmodel> myCollection1;
    
        public ObservableCollection<projectmodel> myCollection
        {
          get => this.myCollection1;
          set
          {
            if (Equals(value, this.myCollection1)) return;
            this.myCollection1 = value;
            OnPropertyChanged();
          }
        }
    
        public projectViewModel()
        {
          myCollection = new ObservableCollection<projectmodel>();
          List<string> lstCity = new List<string>();
          lstCity = new List<string> {"Coimbatore", "Chennai", "Bangalore"};
          List<string> lstTemperature = new List<string>();
          lstTemperature = new List<string> {"17c", "18c", "15c"};
          List<string> lstState = new List<string>();
          lstState = new List<string> {"Andhra", "karnataka", "TamilNadu"};
          myCollection.Add(
            new projectmodel
            {
              City = new ObservableCollection<string>(lstCity),
              Temperature = new ObservableCollection<string>(lstTemperature),
              State = new ObservableCollection<string>(lstState)
            });
        }
    
        public event PropertyChangedEventHandler PropertyChanged;   
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
          this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
      }
    }
