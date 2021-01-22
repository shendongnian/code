    public class MyForm : Form
    {
        public MyForm(FormClosedEventHandler handler) : base()
        {
            this.FormClosed += handler;
        }
    }
