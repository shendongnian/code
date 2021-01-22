    public class Data : INotifyPropertyChanged
    {
      Color overlayColor = Color.Teal;
      public event PropertyChangedEventHandler PropertyChanged;
      public Data()
      {
      }
      public Color OverlayColor
      {
        get
        {
          return overlayColor;
        }
        set
        {
          overlayColor = value;
          NotifyPropertyChanged( "OverlayColor" );
        }
      }
      public void ChangeColor()
      {
        if ( OverlayColor != Color.Tomato )
          OverlayColor = Color.Tomato;
        else
          OverlayColor = Color.DarkCyan;
      }
      private void NotifyPropertyChanged( string propertyName )
      {
        if ( PropertyChanged != null )
          PropertyChanged( this, new PropertyChangedEventArgs( propertyName ) );
      }
    }
