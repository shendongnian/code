    namespace Temp
    {
        public delegate void GlobalMouseClickEventHander(object sender, MouseEventArgs e);
        
        public partial class TestForm : Form
        {
            [Category("Action")]
            [Description("Fires when any control on the form is clicked.")]
            public event GlobalMouseClickEventHander GlobalMouseClick;
    
            public TestForm()
            {
                InitializeComponent();
                BindControlMouseClicks(this);
            }
    
            private void BindControlMouseClicks(Control con)
            {
                con.MouseClick += delegate(object sender, MouseEventArgs e)
                {
                    TriggerMouseClicked(sender, e);
                };
                // bind to controls already added
                foreach (Control i in con.Controls)
                {
                    BindControlMouseClicks(i);
                }
                // bind to controls added in the future
                con.ControlAdded += delegate(object sender, ControlEventArgs e)
                {
                    BindControlMouseClicks(e.Control);
                };            
            }
    
            private void TriggerMouseClicked(object sender, MouseEventArgs e)
            {
                if (GlobalMouseClick != null)
                {
                    GlobalMouseClick(sender, e);
                }
            }
        }
    }
