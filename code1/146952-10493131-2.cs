    private void locateMappingToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OpenFileDialog dg = new System.Windows.Forms.OpenFileDialog();
      if (dg.ShowDialog() == DialogResult.OK)
      {
        fileLocation = Path.GetDirectoryName(dg.FileName);
        try
        {
          if (LoadData())
          {
            //Enable toolbar buttons
            toolStripButton3.Enabled = true;
            toolStripButton5.Enabled = true;
            toolStripButton1.Enabled = true;
            toolStripButton2.Enabled = true;
            searchParm.Enabled = true;
            toolStripButton4.Enabled = true;
            toolStripButton6.Enabled = true;
            exitToolStripMenuItem.Enabled = true;
            EditorForm.ActiveForm.TopLevelControl.Focus();
          }
        }
        catch (Exception exx) 
        {
          MessageBox.Show(exx.Message + Environment.NewLine + exx.InnerException);
        }
      }
    }
