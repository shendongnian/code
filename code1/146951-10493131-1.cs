    <!-- language: c# -->
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
            <b>EditorForm.ActiveForm.TopLevelControl.Focus();</b>
          }
        }
        catch (Exception exx) 
        {
          MessageBox.Show(exx.Message + Environment.NewLine + exx.InnerException);
        }
      }
    }
The lines in bold seem to be key; when the OpenFileDialog closes, focus is reset to the main window (EditorForm.ActiveForm.TopLevelControl.Focus();). When the toolstrip button is clicked, the toolstrip validates itself (this.Validate()) and recognizes the mouse event.
