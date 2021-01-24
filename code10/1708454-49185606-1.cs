    public class BaseForm
    {
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    
        public Button Button1
        {
            get { return button1; }
        }
        public Label Lable1
        {
            get { return label1; }
        }
    
    }
    
    public class Form2 : BaseForm
    {
        public Form2()
        {
            Button1.Text = "J. Doe";
            Lable1.Text = "Kim";
        }
    }
