      private DialogResult DR;
    
        public DialogResult DiaRes
        {
            get { return DR; }
            set { }
        }
    
        public SelectLinksM(string[] allLinks)
        {
            InitializeComponent();            
    
            checkedListBox1.Items.AddRange(allLinks);
            checkedListBox1.CheckOnClick = true;
        }
    
        public void sndLinksSelection_Click(object sender, EventArgs e)
        {
            DR = DialogResult.OK;
    		//<!---- Trigger the action here or nothing will happen
    		DoSomething();
        }
    	
    
    public void DoSomething(){
    		MyClass.SelectLinksM frmSelection = new MyClass.SelectLinksM(linkNames.ToArray());
            frmSelection.Show();
    
            DialogResult result = frmSelection.DiaRes;
    
            if (result == DialogResult.OK)
            {
                MessageBox.Show("I passed a value to the main class!");
            }
    }	
