    public partial class myNumpad : UserControl
    {
        public myNumpad()
        {
            InitializeComponent();
            BindControls(tableLayoutPanel2);
        }
    
        public void BindControls(TableLayoutPanel table)
        {
            for (int i = 0; i <= table.ColumnCount; i++)
            {
                for (int j = 0; j <= table.RowCount; j++)
                {
                    Control c = table.GetControlFromPosition(i, j);
                    if (c is myButton)
                        c.Click += new EventHandler(Numpad_Click);
                }
            }
        }
    
        [BindableAttribute(true), Category("Control"), Description("SetControl")]
        public Control SetControl { get; set; }
    
        private void Numpad_Click(object sender, EventArgs e)
        {
            if (SetControl != null)
            {
                myButton btn = (myButton)sender;
                SetControl.Text += btn.Tag.ToString();
            }
        }
    }
