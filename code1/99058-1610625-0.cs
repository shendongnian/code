public class MyInterestingObject : INotifyPropertyChanged
{
    private int myInterestingInt;
    public event PropertyChangedEventHandler PropertyChanged;
    public int MyInterestingInt
    {
       get { return this.myInterestingInt; }
       set
       {
           if (value != this.myInterestingInt)
           {
               this.myInterestingInt = value;
               this.RaisePropertyChanged("MyInterestingInt");
           }
       }
    }
    private void RaisePropertyChanged(string propertyName)
    {
        var handler = this.PropertyChanged;
        if (handler != null)
        {
             handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
