    foreach(var tbox in new[]
         {
             tbox0, tbox1, tbox2
         })
    {
        tbox.KeyPress += (sender,e) => keypressed(sender,e);
    }
    
    private void keypressed(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Back)
            ((Control)sender).GetNextControl((Control)sender, false).Select(); // .Focus()
    }
