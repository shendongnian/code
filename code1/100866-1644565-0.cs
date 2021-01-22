    public partial class Form1 : Form
    {
        public bool ButtonsEnabled { get; set; }
    
        public Form1()
        {
            InitializeComponent();
    
            // Enable by default
            ButtonsEnabled = true;
    
            // Set the bindings.
            FindButtons(this);
        }
    
        private void button_Click(object sender, EventArgs e)
        {
            // Set the bound property
            ButtonsEnabled = false;
    
            // Force the buttons to update themselves
            this.BindingContext[this].ResumeBinding();
    
            // Renable the clicked button
            Button thisButton = sender as Button;
            thisButton.Enabled = true;
        }
    
        private void FindButtons(Control control)
        {
            // If the control is a button, bind the Enabled property to ButtonsEnabled
            if (control is Button)
            {
                control.DataBindings.Add("Enabled", this, "ButtonsEnabled");
            }
    
            // Check it's children
            foreach(Control child in control.Controls)
            {
                FindButtons(child);
            }
        }
    }
