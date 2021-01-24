    if(picturebox1.Image != null)
       picturebox1.Image.Dispose();
    
    picturebox1.Image = null;
    
    OpenFileDialog ofDlg = new OpenFileDialog();
    ofDlg.Filter = "Image files|*.png";
    if (DialogResult.OK == ofDlg.ShowDialog())
    {
         picturebox1.Image = Image.FromFile(ofDlg.FileName); //Out of memory.
    }
