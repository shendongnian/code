    public class Key {
    
    private ConcurrentDictionary<string, bool> _setProps = new ConcurrentDictionary<string, bool>();
    private string _prop1;
    
    public string Prop1 {
    
    get { return _prop1; }
    set { 
        if(!_setProps.ContainsKey(nameof(Prop1)){
            _setProps.Add(nameof(Prop1), true);
            _prop1 = value;
        }
      }
     }
    }
