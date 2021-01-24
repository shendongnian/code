    public Form1
    {
    textBoxPW.Controls.Add(pictureBoxEye);
    pictureBoxEye.Location = new Point(95,0);
    pictureBoxEye.BackColor = Color.Transparent;
    
    textBoxPW.UseSystemPasswordChar = true;
    //Subscribe to Event
    pictureBoxPW.MouseDown += new MouseEventHandler(pictureBoxPW_MouseDown);
    pictureBoxPW.MouseUp += new MouseEventHandler(pictureBoxPW_MouseUp);
    }
