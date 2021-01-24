    public partial class MyFirstForm : Form
    {
        private string SomeString = "Some private variable";
        public string PublicString = "Some public variable";
        public MyFirstForm()
        {
            InitializeComponent();            
        }
        private void OnButtonClick(object sender, EventArgs e)
        {
            using(Form2 f = new Form2(this))
            {
                f.ShowDialog();
            }
        }
    }
    public class Form2 : Form
    {
        private MyFirstForm form;
    
        public Form2(MyFirstForm form)
        {
            InitializeComponent();
            if(form == null)
                throw new Exception("Form you passed is not assigned!");
            this.form = form;
            form.SomeString = "I just changed string in first form";
        }
    }
