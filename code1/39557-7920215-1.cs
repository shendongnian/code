         public static class GenericHandler
         {
             public static void HandleAnyEvent(object sender, EventArgs e)
             {
                 //handle
             }
         }
         public class SomeClass
         {
             void RegisterEvents()
             {
                 var r = new EventRaiser();
     
                 r.ImportantThingHappened += GenericHandler.HandleAnyEvent;
             }
         }
