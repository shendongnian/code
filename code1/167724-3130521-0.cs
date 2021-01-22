    abstract class Container : INotifyPropertyChanged
    {
      Dictionary<string, object> values;
      
      protected object this[string name]
      {
        get {return values[name]; }
        set 
        { 
          values[name] = value;
          PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
      }
    }
    
    class Foo : Container
    {
      public int Bar 
      {
        {get {return (int) this["Bar"]; }}
        {set { this["Bar"] = value; } }
      }
    }
