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
        public static void OnMyEvent(Form frm)
        {
            if (MyEvent != null)
                MyEvent(frm, new EventArgs());
        }
    }
    public class Form2 : Form
    {
        private void SaveButton(object sender, EventArgs e)
        {
            Form1.OnMyEvent(this); 
        }
    }
