    public class FooBat {
       public string Name { get; set; }
       public string Label {
           get {
               if (string.IsNullOrEmpty(_label)) 
                  _label = Name;
               return _label;
           }
           set { 
              _label = value; 
              this.IsLabelSet = true;
           }
       }
       public bool IsLabelSet { get; set; }
    }
