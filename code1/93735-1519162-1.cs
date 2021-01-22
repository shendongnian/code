    public class PassiveForm : Form
    {
        public PassiveForm()
        {
            InitializeComponent();
        }
        
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams parameter = base.CreateParams;
                parameter.ExStyle |= 0x80; // Apply toolbar-property
                parameter.ExStyle |= 0x8000000; // Revoke acitvation
                return parameter;
            }
        }
        
        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }
    }
