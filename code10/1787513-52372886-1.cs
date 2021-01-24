    public class SelectorEventosViewModel : INotifyPropertyChanged
    {
       public ObservableCollection<SelectorEvents> SelectorEvents { get; set; } = new ObservableCollection<SelectorEvents>();
    
       private SelectorEvents _currentSelection;
    
       public SelectorEventosViewModel()
       {
          PopulaSelectorEvents();
       }
    
       private void PopulaSelectorEvents()
       {
          SelectorEvents.Add(new SelectorEvents { Key = "evtInfoEmpregador", Value = "S1000" });
          SelectorEvents.Add(new SelectorEvents { Key = "evtTabEstab", Value = "S1005" });
          SelectorEvents.Add(new SelectorEvents { Key = "evtTabRubricas", Value = "S1010" });
       }
    
       public SelectorEvents CurrentSelection
       {
          get => _currentSelection;
          set
          {
             if (_currentSelection == value)
                return;
    
             _currentSelection = value;
             OnPropertyChanged();
          }
       }
    
       public event PropertyChangedEventHandler PropertyChanged;
    
       [NotifyPropertyChangedInvocator]
       protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
       {
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
       }
    }
