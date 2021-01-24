    public class Form1 : Form, IReceiver
    {
        Label l = new Label();
        public Form1()
        {
            this.Controls.Add(l);
            Messenger.InitializeReceiver(this);
        }
        public void WriteMessage(string message)
        {
            l.Text = message;
        }
    }
