    private void button1_Click(object sender, EventArgs e)
    {
    SaveFileDialog SvDlg = new SaveFileDialog();
    
      if (SvDlg.ShowDialog() == DialogResult.OK)
      {
          textBox1.Text = SvDlg.FileName;
      }
      else 
      {
          MessageBox.Show("No file selected.");
      }
    }
