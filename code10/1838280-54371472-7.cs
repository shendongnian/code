    public class Form1 : Form, IReceiver
    {
        Label l = new Label();
        public Form1()
        {
            this.Controls.Add(l);
            // We pass to the Messenger static class the instance of this form
            // because we implement the IReceiver interface. 
            Messenger.InitializeReceiver(this);
        }
        // This is how we satisfy the Interface requirement. 
        // We add a method called WriteMessage that receives a string 
        // and doesn't return anything
        public void WriteMessage(string message)
        {
            // Do whatever you want the message for this class
            l.Text = message;
        }
    }
