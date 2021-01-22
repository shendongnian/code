    private void button1_Click(object sender, EventArgs e)
    {
        OpenFileDialog od = new OpenFileDialog();
        od.InitialDirectory = Environgment.SpecialFolder.System;
        od.Multiselect = true;
        if (od.ShowDialog() == DialogResult.OK)
        {
           // do stuff
           // od.Filenames will hold the string[] of selected files
        }
    }
