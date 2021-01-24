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
          MyCollection = new ObservableCollection<Projectmodel>()
          {
            new ProjectModel()
            {
               City = new ObservableCollection<string>()
                  {
                     "Coimbatore", "Chennai", "Bangalore"
                  },
               Temperature = new ObservableCollection<string>()
                  {
                     "17c", "18c", "15c"
                  },
               State = new ObservableCollection<string>()
                  {
                     "Andhra", "karnataka", "TamilNadu"
                  }
            }
          };
        }
    
        public event PropertyChangedEventHandler PropertyChanged;   
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
          this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
      }
    }
