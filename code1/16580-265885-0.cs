    public class Form1 : Form 
    {
        private Label label;
 
        // Construction etc as normal
        public string LabelText
        {
             get { return label.Text; }
             set { label.Text = value; }
        }
        public Form2 CreateForm2()
        {
            return new Form2(this);
        }
    }
    public class Form2 : Form
    {
        private Form1 form1;
        public Form2(Form1 form1)
        {
            this.form1 = form1;
            // Normal construction
        }
        public void SayHello()
        {
            form1.LabelText = "Hello";
        }
    }
