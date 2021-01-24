    public partial class YourLoginForm
    {
        private MainForm mf;
    
        //This is standard constructor
        public YourLoginForm()
        {
            InitializeComponents();
        }
    
        //This is new constructor
        public YourLoginForm(MainForm form)
        {
            InitializeComponents();
            mf = form; //Setting our globally accessible variable (within this class) to reference of passed form (main form)
        }
    
        private void LoginButtonClick(object sender, EventArgs e)
        {
            mf.AddTab("I have passed this string"); //Accessing public void from main form.
        }
    }
