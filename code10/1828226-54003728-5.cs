    namespace MyProject.ViewModels    
    {
      public class ProjectViewModel : INotifyPropertyChanged
      {
        private ObservableCollection<Projectmodel> myCollection;
    
        public ObservableCollection<Projectmodel> MyCollection
        {
          get => this.myCollection;
          set
          {
            if (Equals(value, this.myCollection)) return;
            this.myCollection = value;
            OnPropertyChanged();
          }
        }
    
        public ProjectViewModel()
        {
          MyCollection = new ObservableCollection<Projectmodel>();
          List<string> lstCity = new List<string>();
          lstCity = new List<string> {"Coimbatore", "Chennai", "Bangalore"};
          List<string> lstTemperature = new List<string>();
          lstTemperature = new List<string> {"17c", "18c", "15c"};
          List<string> lstState = new List<string>();
          lstState = new List<string> {"Andhra", "karnataka", "TamilNadu"};
          MyCollection.Add(
            new ProjectModel
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
