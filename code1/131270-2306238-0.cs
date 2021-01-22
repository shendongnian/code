    public class MyForm1 : Form, IMyForm1
    {
       ... // Bunch of other stuff
       public event<EventHandler> onButtonClick;
    }
    public class MyPresenter
    {
       public static void Main()
       {
           ... // Other stuff
           myForm1.onButtonClick += new EventHandler<EventArgs>(ButtonHandler);
       }
       private void ButtonHandler(object sender, EventArgs e)
       {
           // Add item to form1
           ...
           // Add item to form2. Eg:
           form2.AddListItem(...);
       }
    }
       
