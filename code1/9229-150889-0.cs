    using System;
    using System.Windows.Forms;
    
    namespace TestApp
    {
        class DGV : DataGridView
        {
            private string test = "";
    
            protected override void OnDoubleClick(EventArgs e)
            {
                MessageBox.Show(test + "OnDoubleClick");
            }
    
            protected override void OnCellMouseDoubleClick(System.Windows.Forms.DataGridViewCellMouseEventArgs e)
            {
                MessageBox.Show(test + "OnCellMouseDoubleClick");
            }
    
            protected override void OnCellMouseClick(System.Windows.Forms.DataGridViewCellMouseEventArgs e)
            {
                if (e.Clicks == 1)
                {
                    // Had to do this with a variable as using a MessageBox
                    // here would block us from pulling off a double click
                    test = "1 click ";
                    base.OnCellMouseClick(e);
                }
                else
                {
                    MessageBox.Show("OnCellMouseClick");
                }
            }
        }
    }
