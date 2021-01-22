    public class MyForm : Form
    {
        protected MyForm()
        {
        }
        protected int MyValue { get; set; }
    
        public static int GetResult()
        {
            using(MyForm myForm = new MyForm())
            {
                if(myForm.ShowDialog == DialogResult.OK)
                    return myForm.MyValue;   
            }
            return -1;
        }
    }
