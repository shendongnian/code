    private void textBox1_KeyDown(object sender,
    System.Windows.Forms.KeyEventArgs e)
    {
      if(e.KeyCode ==Keys.F1)
      {
        System.Diagnostics.Process.Start(@"C:\WINDOWS\Help\mspaint.chm");
      }
    }
