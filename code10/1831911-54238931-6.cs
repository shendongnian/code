    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace Magacin
    {
        public partial class TestForm : Form
        {
            bool HandleSelectionChange = true;
            bool HandleCheckChange = true;
            bool TempStopDeslect = false;
    
            bool dragging = false;
            bool multiJob = false;
            
    
            public TestForm()
            {
                InitializeComponent();
    
    
                listView1.CheckBoxes = true;
                this.listView1.ItemCheck += OnCheck;
                this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
                this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
                this.listView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyUp);
                this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
                this.listView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseUp);
    
    
                listView1.Items.Add("Item1");
                listView1.Items.Add("Item2");
                listView1.Items.Add("Item3");
            }
    
            private ListViewItem GetItemFromPoint(ListView listView, Point mousePosition)
            {
                Point localPoint = listView.PointToClient(mousePosition);
                return listView.GetItemAt(localPoint.X, localPoint.Y);
            }
    
            private void OnCheck(object sender, ItemCheckEventArgs e)
            {
                if (!HandleCheckChange)
                    return;
    
                ListViewItem item = GetItemFromPoint(listView1, Cursor.Position);
    
                if (item == null)
                    return;
    
                if (e.Index != item.Index)
                {
                    TempStopDeslect = true;
                    e.NewValue = e.CurrentValue;
                    return;
                }
    
                HandleSelectionChange = (multiJob) ? false : true;
                if (e.NewValue == CheckState.Checked)
                {
                    listView1.Items[e.Index].Selected = true;
                }
                else
                {
                    listView1.Items[e.Index].Selected = false;
                }
                HandleSelectionChange = true;
            }
            private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
            {
                if (!HandleSelectionChange)
                    return;
    
                bool temp = e.IsSelected;
    
                if (!TempStopDeslect)
                {
                    if (!multiJob && !dragging)
                    {
                        foreach (ListViewItem i in listView1.Items)
                        {
                            i.Checked = false;
                            i.Selected = false;
                        }
                    }
                }
                else
                    TempStopDeslect = false;
    
                HandleCheckChange = false;
                e.Item.Selected = temp;
                e.Item.Checked = e.IsSelected;
                HandleCheckChange = true;
            }
    
            private void listView1_MouseDown(object sender, MouseEventArgs e)
            {
                ListViewItem item = GetItemFromPoint(listView1, Cursor.Position);
                if (item == null)
                    dragging = true;
            }
            private void listView1_MouseUp(object sender, MouseEventArgs e)
            {
                dragging = false;
            }
    
            private void listView1_KeyDown(object sender, KeyEventArgs e)
            {
                if(e.KeyCode == Keys.Control) // Change this to whatever you want
                    multiJob = true;
            }
            private void listView1_KeyUp(object sender, KeyEventArgs e)
            {
                multiJob = false;
            }
        }
    }
