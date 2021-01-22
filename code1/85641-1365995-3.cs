    interface IActionable
    {
       void Do ();
    }
   
   
    public abstract class ActionableBase : IActionable
    {
       // some other things
       
       public abstract void Do ();
    }
   
   
    public class UpdateAction : ActionableBase
    {
       public override void Do ()
       {
           // Update Code
       }
    }
    ...
    IActionable a = ...;
    a.Do();
     
