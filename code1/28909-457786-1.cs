    public partial class Form1 : Form
    {
        public enum FormContextMode
        {
            Add,
            Edit
        }
    
        private FormContextMode m_mode = FormContextMode.Add; 
    
        public Form1( FormContextMode mode )
        {
            InitializeComponent();
            m_mode = mode;
            Load += delegate { UpdateForm(); };
        }
    
        private void UpdateForm()
        {
            if( m_mode == FormContextMode.Add )
            {
                Text = "Add member";    
            }
            else if( m_mode == FormContextMode.Edit )
            {
                Text = "Change role";
                userTextBox.Enabled = false;
                searchkButton.Visible = false;
            }
        }
    }
