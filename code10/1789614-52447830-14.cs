    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using Prism.Commands;
    
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
                return new DelegateCommand<string>(name =>
                {
                   NamesTwo.Remove(name);
                   Names.Add(name);
                   SelectedNameTwo = "";
                });
             }
          }
    
          public ICommand MyDoubleClickCommand
          {
             get
             {
                return new DelegateCommand<string>(name =>
                {
                   Names.Remove(name);
                   NamesTwo.Add(name);
                   SelectedName = "";
                });
             }
          }
    
          public event PropertyChangedEventHandler PropertyChanged;
       }
    }
