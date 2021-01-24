    namespace WpfExample
    {
       public class MyViewModel : INotifyPropertyChanged
       {
          private string _selectedName;
          private string _selectedNameTwo;
    
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
    
          public ObservableCollection<string> NamesTwo { get; } = new ObservableCollection<string>(new List<string>());
    
          public string SelectedName
          {
             get { return _selectedName; }
             set { _selectedName = value; OnPropertyChanged(); }
          }
    
          public string SelectedNameTwo
          {
             get { return _selectedNameTwo; }
             set { _selectedNameTwo = value; OnPropertyChanged(); }
          }
    
          public ICommand MyOtherDoubleClickCommand
          {
             get
             {
                return new DelegateCommand(() =>
                {
                   var selected = SelectedNameTwo;
                   NamesTwo.Remove(selected);
                   Names.Add(selected);
                   SelectedNameTwo = "";
                });
             }
          }
    
          public ICommand MyDoubleClickCommand
          {
             get
             {
                return new DelegateCommand(() =>
                {
                   var selected = SelectedName;
                   Names.Remove(selected);
                   NamesTwo.Add(selected);
                   SelectedName = "";
                });
             }
          }
    
          public event PropertyChangedEventHandler PropertyChanged;
       }
    }
