    public class FooBat {
       public string Name { get; set; }
       public bool IsLabelSet { get; set; }
       public string Label {
          get {
             if (IsLabelSet)
                return _label;
             else
                return Name;
          }
          set {
             IsLabelSet = value != null;
             _label = value;
          }
       }
    }
