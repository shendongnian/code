    public class MyTcpListener
        {
            private Form1 form1;
            public MyTcpListener(Form1 form1)
            {
            this.form1 = form1;
            }
    public partial class Form1 : Form
        { // Some code ...
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //Start the thread ....
            //Originally I never instantiated an instance of MyTcpListener class
            MyTcpListener mytcplistener = new MyTcpListener(this);
    
