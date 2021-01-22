    public class ControlInvader
    {
      private static readonly System.Reflection.FieldInfo layoutSuspendCount = 
          typeof(Control).GetField("layoutSuspendCount",
              System.Reflection.BindingFlags.Instance | 
              System.Reflection.BindingFlags.NonPublic);
      private readonly Control control;        
        
      public bool IsSuspended 
      {
        get 
        {
          return 0 ==  (byte)layoutSuspendCount.GetValue(this.control);
        }
      }
    
      public Suspendable(Control control) { this.control = control; }     
    }
