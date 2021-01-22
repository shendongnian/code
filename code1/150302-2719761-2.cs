    private string _name = "Foo"; // field for property Name;
    private bool _enabled = false; // field for property Enabled;
    public string Name{ // This is a readonly property.
      get {
        return _name;  
      }
    }
    public bool Enabled{ // This is a read- and writeable property.
      get{
        return _enabled;
      }
      set{
        _enabled = value;
      }
    } 
