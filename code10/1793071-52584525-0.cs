    public interface IPerson {
       int Health {get; set;}
       int Damage {get; set;}
    }
    
    public class ActionService(){
      public IPerson SelectedClass {get;set;}
      public IPerson ActingClass {get;set;}
    
    public void Hit()
    {
       this.SelectedClass.Health -= this.ActingClass.Damage;
    }
    
    }
