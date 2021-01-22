// Note: The CustomDelegate signature is defined as:
// public delegate object CustomDelegate(params object[] args);
CustomDelegate handler = delegate
                         {
                           Console.WriteLine("Button Clicked!");
                           return null;
                         };
Button myButton = new Button();
// Connect the handler to the event
EventBinder.BindToEvent("Click", myButton, handler);
