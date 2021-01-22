    private void copyToolStripMenuItem_Click(object sender, EventArgs e)
    {
           foreach (Control myControl in tabControl1.SelectedTab.Controls)
           {
                 if (myControl is DataGridView))
                 {
                        DataGridView tempdgv = (DataGridView)myControl;
                        DataObject dataObj = tempdgv.GetClipboardContent();
                        try
                        {
                            Clipboard.SetDataObject(dataObj, true);
                        }
                        catch (Exception ex)
                        {
                             // Do Something
                        }
                        finally
                        {
                            if (selectAllToolStripMenuItem.Checked)
                            {
                                selectAllToolStripMenuItem_Click(this, EventArgs.Empty);
                            }
    
                        }
                    }
         }
    }
