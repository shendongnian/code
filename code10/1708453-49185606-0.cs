    public class BaseForm
    {
        
        //All BaseForm child classes will have access to the protected elements
        protected System.Windows.Forms.Button button1;
        protected System.Windows.Forms.Label label1;
    }
    
    public class Form2 : BaseForm
    {
        public Form2()
        {
            button1.Text = "J. Doe";
            label1.Text = "Kim";
        }
    }
