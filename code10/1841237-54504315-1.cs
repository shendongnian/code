    public class TapViewModel : INotifyPropertyChanged
    {
      ICommand tapCommand;
      public TapViewModel () 
      {
        tapCommand = new Command (OnTapped);
      }
      public ICommand TapCommand 
      {
        get { return tapCommand; }
      }
      void OnTapped (object s)
      {
        //DO whatever you want
      }
}
