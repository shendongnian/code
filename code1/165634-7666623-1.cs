        DateTime _lastRenav = DateTime.MinValue;
        
        public Form1()
        {
            InitializeComponent();
            listBox1.LostFocus += new EventHandler(listBox1_LostFocus);
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            axAcroPDF1.src = "sample.pdf";  //this will cause adobe to take away the focus
            _lastRenav = DateTime.Now;
        }
        void listBox1_LostFocus(object sender, EventArgs e)
        {
            //restores focus if it were the result of a listbox navigation
            if ((DateTime.Now - _lastRenav).TotalSeconds < 1)
                listBox1.Focus();
        }
