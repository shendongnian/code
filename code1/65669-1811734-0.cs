    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace Tabber
    {
        public partial class MainForm : Form
        {
            public MainForm()
            {
                InitializeComponent();
                ControlList = new List<Control>(new Control[] {button1, button2, button3, button4});
            }
    
            private List<Control> ControlList { get; set; }
    
            public Control NextControl { get; set; }
    
            private void MainForm_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Tab)
                {
                    using (var chooseDialog = new Chooser(this, ControlList))
                    {
                        if (chooseDialog.ShowDialog() == DialogResult.OK)
                        {
                            if (NextControl != null)
                            {
                                NextControl.Focus();
                            }
                        }
                    }
                }
            }
        }
    }
