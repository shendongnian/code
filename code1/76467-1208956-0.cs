    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
    
            YourUserControl userctr = new YourUserControl();
            
            //Sent the event handler linked to OnSelectedValueChanged
            userctrl.HandleSelectValue(new EventHandler(OnSelectedValueChanged));
        }
    
        private void OnSelectedValueChanged(object sender, EventArgs e)
        {
            //Do something
        }
    }
    
    public partial class YourUserControl : UserControl
    {
        public void HandleSelectValue(EventHandler handler)
        {
            this.comboBox1.SelectedIndexChanged += handler;
        }
    }
