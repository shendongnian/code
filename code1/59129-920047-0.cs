    public class Form1 : Form
    {
        public static event EventHandler MyEvent;
    
        public Form1()
        {
             Form1.MyEvent += new EventHandler(MyEventMethod); 
        }
        private void MyEventMethod(object sender, EventArgs e)
        {
             //do something here
        }
    }
    
    public class Form2 : Form
    {
        private void SaveButton(object sender, EventArgs e)
        {
             if(Form1.MyEvent != null)
                  Form1.Myevent(this, new EventArgs());
        }
    }
