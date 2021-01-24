    public class JackieChan : IPerson {
    
      public int Health {get;set;} = 120;
      public int Damage {get;set;} = 20;
    }
    
    public class Terminator: IPerson {
    
      public int Health {get;set;} = 500;
      public int Damage {get;set;} = 25;
    }
    
    var action = new ActionService { SelectedClass = new JackieChan(), ActingClass = new Terminator() };
    
    action.Hit();
