    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                foreach (ToolStripMenuItem item in toolStripMenuItemColors.DropDownItems)
                {
                    item.Click += ItemClick;
                }
            }
    
            private void ItemClick(object sender, EventArgs e)
            {
                foreach (ToolStripMenuItem item in toolStripMenuItemColors.DropDownItems)
                {
                    if (item.Equals(sender))
                    {
                        item.Checked = true;
                    }
                    else
                    {
                        item.Checked = false;
                    }
                }
    
                string color =((ToolStripMenuItem)sender).Text;
                Color newColor = this.BackColor;
    
                switch (color)
                {
                    case "Red":
                        newColor = Color.Red;
                        break;
                    case "Blue":
                        newColor = Color.Blue;
                        break;
                    case "Green":
                        newColor = Color.Green;
                        break;
                    default:
                        break;
                }
                BackColor = newColor;
            }
        }
    }
