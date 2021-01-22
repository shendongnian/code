    public enum ActionType
    {
       Swim, Vote, Fly
    };
 
    public interface IBehavior
    {
       public boolean ActionReady;
       public ActionType _type;
       
       public void performMyAction();
    }
    public abstract Foo
    {
      IBevahior[] behaviors;
    
      // if you want to keep track of behavior states as on or off
      void perform()
      {
        for(int i = 0; i< behaviors.length; i++)
        {
           if(behaviors[i].ActionReady)
           {
              behaviors[i].performMyAction();
           }
        }
      }
    
      // if you want to call behaviors individually
      void performType(ActionType type)  // however you want to make the distinction
      {
         for(int i = 0; i < behaviors.length; i++)
         {
            if(behaviors[i].type = type)
            {
                behaviors[i].performMyAction();
            }
         }
      }
    }
