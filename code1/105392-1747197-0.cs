    public Form2()
        {
            InitializeComponent();
            
            TabControl tc = new TabControl();
            toolStripContainer1.ContentPanel.Controls.Add(tc);
            tc.Dock = DockStyle.Fill;
            TextBox selectedTextBox = null;
            pasteButton.Click += (_, __) => selectedTextBox.Paste(Clipboard.GetText(TextDataFormat.Text));
            int pages = 0;
            newTabButton.Click += (_,__) => {                
                TextBox tb = new TextBox { Multiline = true, Dock = DockStyle.Fill, ScrollBars = ScrollBars.Vertical };
                TabPage tp = new TabPage("Page " + (++pages).ToString());                
                tc.Selected += (o, e) => selectedTextBox = e.TabPage == tp ? tb: selectedTextBox;
                tp.Controls.Add(tb);
                tc.TabPages.Add(tp);
                tc.SelectedTab = tp;
                selectedTextBox = tb;
            };           
                           
        }
