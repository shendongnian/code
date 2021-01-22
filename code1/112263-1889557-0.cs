    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    namespace DefinedRectangles
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                innerItems = new List<DisplayRect>();
                innerItems.Add(new DisplayRect(new Rectangle(0, 0, 50, 50), Color.Blue, true));
                innerItems.Add(new DisplayRect(new Rectangle(76, 0, 100, 50), Color.Green, false));
                innerItems.Add(new DisplayRect(new Rectangle(0, 76, 50, 100), Color.Pink, false));
                innerItems.Add(new DisplayRect(new Rectangle(101, 101, 75, 75), Color.Orange, true));
            }
            List<DisplayRect> innerItems;
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                foreach(DisplayRect dispItem in innerItems)
                {
                    dispItem.OnPaint(this, e);
                }
            }
            private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
            {
                foreach (DisplayRect dispItem in innerItems)
                {
                    dispItem.OnHitTest(this, e);
                }
            }
        }
    }
