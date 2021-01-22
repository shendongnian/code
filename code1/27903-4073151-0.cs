    public class MyController : Controller 
    {
        public ActionResult MyAction(string button)
        {
             switch(button)
             {
                 case "send":
                     this.DoSend();
                     break;
                 case "cancel":
                     this.DoCancel();
                     break;
             }
        }
    }
