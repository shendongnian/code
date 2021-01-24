    public partial class MyControl : UserControl
    {
       public event EventHandler<MyImportantEventA> OnImportantThingHappend;
     
       //Event-Invoker
       protected virtual void OnOnImportantThingHappend(MyImportantEventA e)
            {
                OnImportantThingHappend?.Invoke(this, e);
            }
    }
    
    //Data of your event. Customize as you like/need.
    public class MyImportantEventA : EventArgs   
     {
                public string Message { get; set; }
     }
