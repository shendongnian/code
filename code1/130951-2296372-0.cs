    public partial class Window1 : Window, INotifyPropertyChanged
       {
           string[] _options;
           public string[] Options
           {
               get
               {  return _options;         }
               set
               {
                   _options = value;
                   if (this.PropertyChanged != null)
                       this.PropertyChanged(this, new PropertyChangedEventArgs("Options"));
               }
           }
