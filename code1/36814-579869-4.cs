    public class FooBat {
       public string Name { get; set; }
       private string _label;
       public bool IsLabelSet { get; set; }
      
       public string GetLabel(bool ignoreIsLabelSet) {
          if(ignoreIsLabelSet || IsLabelSet) 
             return _label;
          else
             return Name;
       }
       public void SetLabel(string value) {
          _label = value;
          this.IsLabelSet = !string.IsNullOrEmpty(value);
       }
