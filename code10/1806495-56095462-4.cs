    public class MyViewModel : IMyDataGridSource, INotifyPropertyChanged
    {
       public event PropertyChangedEventHandler PropertyChanged;
       protected virtual void RaisePropertyChanged(string propertyName)
       { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    
       public ObservableCollection<OneItem> ItemsCollection { get; set; } 
          = new ObservableCollection<OneItem>();
    
    
       public void Button_Refresh()
       {
          ItemsCollection = new ObservableCollection<OneItem>
          {
             new OneItem{ DayName = "Sunday", DayOfWeek = 0},
             new OneItem{ DayName = "Monday", DayOfWeek = 1},
             new OneItem{ DayName = "Tuesday", DayOfWeek = 2},
             new OneItem{ DayName = "Wednesday", DayOfWeek = 3},
             new OneItem{ DayName = "Thursday", DayOfWeek = 4},
             new OneItem{ DayName = "Friday", DayOfWeek = 5 },
             new OneItem{ DayName = "Saturday", DayOfWeek = 6 }
          };
          RaisePropertyChanged("ItemsCollection");		
       }
    
    
       // THIS is the magic hook exposed that will allow you to rebuild your
       // grid column headers
       public void MyDataGridItemsChanged(MyDataGrid mdg)
       {
          // if null or no column count, get out.
          // column count will get set to zero if no previously set grid
          // OR when the items grid is cleared out. don't crash if no columns
          if (mdg == null)
             return;
    
          mdg.Columns[0].Header = "123";
       }
    }
