    namespace WpfExample
    {
       public class MyViewModel : INotifyPropertyChanged
       {
          private string _selectedName;
    
          protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
          {
             PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
          }
    
          public ObservableCollection<string> Names { get; } 
             = new ObservableCollection<string>(new List<string>
             {
                "Name1",
                "Name2",
                "Name3",
                "Name4",
                "Name5"
             });
    
          public string SelectedName
          {
             get { return _selectedName; }
             set { _selectedName = value; OnPropertyChanged(); }
          }
    
          public ICommand MyDoubleClickCommand
          {
             get
             {
                return new DelegateCommand(() =>
                {
                   var selected = SelectedName;
                   Names.Remove(selected);
                   SelectedName = "";
                });
             }
          }
    
          public event PropertyChangedEventHandler PropertyChanged;
       }
    }
