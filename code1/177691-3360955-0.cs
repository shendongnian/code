    private File f = null;
    for (int i = 0; i < 10; i++)
    {
        ii = new RadioButton();
        ii.Text = i.ToString();
        ii.Location = new Point(20, tt);
        ii.Tag = fileArray[i]; // Assuming you have your files in an array or similar
        ii.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
        tt = tt + 20;
        panel1.Controls.Add(ii);
    }
    
    private void Radio_CheckedChanged(object sender, EventArgs e)
    {
        RadioButton r = (RadioButton)sender;
        f = (File)r.Tag;
    }
