    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace Tabber
    {
        public partial class Chooser : Form
        {
            public Chooser(MainForm sender, List<Control> controls)
            {
                Sender = sender;
                InitializeComponent();
    
                foreach (Control control  in controls)
                {
                    listBox1.Items.Add(control);
                }
                listBox1.DisplayMember = "Name";
                listBox1.SetSelected(0, true);
            }
    
            private MainForm Sender { get; set; }
    
            private void Chooser_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Tab)
                {
                    if (listBox1.SelectedIndex == listBox1.Items.Count - 1)
                    {
                        listBox1.SetSelected(0, true);
                    }
                    else
                    {
                        listBox1.SetSelected(listBox1.SelectedIndex + 1, true);
                    }
                    e.Handled = true;
                }
            }
    
            private void listBox1_KeyUp(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.ControlKey)
                {
                    Sender.NextControl = (Control) listBox1.SelectedItem;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
