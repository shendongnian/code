    public partial class dragdropentity : UserControl
        {
            public dragdropentity()
            {
                InitializeComponent();
            }
    
            private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                //            MessageBox.Show(listBox1.SelectedIndex.ToString() + '\n' + listBox1.SelectedItem.ToString());
                pictureBox1.Load(@"D:\My\Documents\Visual Studio 2010\Projects\ClassLibrary1\ClassLibrary1\Images\" + listBox1.SelectedItem.ToString() + ".png");
            }
            void listBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
            {
                int indexOfItem = listBox1.IndexFromPoint(e.X, e.Y);
                if (indexOfItem >= 0 && indexOfItem < listBox1.Items.Count)  // check that an string is selected
                {
                    listBox1.DoDragDrop(listBox1.Items[indexOfItem], DragDropEffects.Copy);
                }
    
                //           throw new System.NotImplementedException();
            }
    
    
            void listBox1_QueryContinueDrag(object sender, System.Windows.Forms.QueryContinueDragEventArgs e)
            {
                ListBox lb = (ListBox)sender;
                textBox1.AppendText('\n' + e.Action.ToString() + '\n'+ this.Name.ToString());
    
                if (e.Action == DragAction.Drop)
                {
                    Autodesk.AutoCAD.ApplicationServices.Application.DoDragDrop(this, "Drag & drop successful!!!", System.Windows.Forms.DragDropEffects.All, new DragDrop());
                }
            }
    }
