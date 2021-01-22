    public class Person {
     private string _name;
     public event EventHandler NameChanging;     
     public event EventHandler NameChanged;
     public string Name{
      get
      {
         return _name;
      }
      set
      {
         OnNameChanging();
         _name = value;
         OnNameChanged();
      }
     }
     private void OnNameChanging(){
       EventHandler localEvent = NameChanging;
       if (localEvent != null) {
         localEvent(this,EventArgs.Empty);
       }
     }
 
     private void OnNameChanged(){
       EventHandler localEvent = NameChanged;
       if (localEvent != null) {
         localEvent(this,EventArgs.Empty);
       }
     }
    }
