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
         NameChanging?.Invoke(this,EventArgs.Empty);       
     }
 
     private void OnNameChanged(){
         NameChanged?.Invoke(this,EventArgs.Empty);
     }
    }
