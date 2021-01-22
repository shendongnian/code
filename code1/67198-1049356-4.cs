public class SomeClass : INotifyPropertyChanged {
  private string _somestring;
  public string SomeString{
    get{return _somestring;}
    set{ _somestring = value; OnPropertyChanged("SomeString");}
  }
  public event PropertyChangedEventHandler PropertyChanged;
  protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
}
