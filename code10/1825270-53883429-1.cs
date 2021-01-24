    public class MainWindowViewModel : INotifyPropertyChanged
    {
     private ObservableCollection<Results> searchResults;
     public ObservableCollection<Results> SearchResults { get => searchResults; set { searchResults = value; NotifyPropertyChanged(); } }
    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    #endregion
    //Other code here.... 
    }
