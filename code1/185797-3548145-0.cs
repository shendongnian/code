    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    class Form1 : Form
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    
        List<MyItem> _selResolutions;
        CheckedListBox cklResolutions;
    
        public Form1()
        {
            Controls.Add(cklResolutions = new CheckedListBox { Dock = DockStyle.Fill });
    
            _selResolutions = new List<MyItem>();
            _selResolutions.Add(new MyItem { LongDesc = "One", Selected = true });
            _selResolutions.Add(new MyItem { LongDesc = "Two", Selected = false });
            _selResolutions.Add(new MyItem { LongDesc = "Three", Selected = false });
            _selResolutions.Add(new MyItem { LongDesc = "Four", Selected = true });
    
            cklResolutions.DataSource = new BindingSource(_selResolutions, null);
            cklResolutions.DisplayMember = cklResolutions.ValueMember = "LongDesc";
    
            UpdateCheckBoxes();
    
            cklResolutions.KeyUp += new KeyEventHandler(cklResolutions_KeyUp);
        }
    
        private void UpdateCheckBoxes()
        {
            for (int n = 0; n < _selResolutions.Count; n++)
                cklResolutions.SetItemChecked(n, _selResolutions[n].Selected);
        }
    
        void cklResolutions_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                int index = cklResolutions.SelectedIndex;
                if (index >= 0)
                {
                    BindingSource bs = cklResolutions.DataSource as BindingSource;
                    bs.RemoveAt(index);
                    UpdateCheckBoxes();
                }
            }
        }
    }
    
    class MyItem
    {
        public string LongDesc { get; set; }
        public bool Selected { get; set; }
    }
