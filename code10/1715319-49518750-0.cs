    private void button_Click(object sender, EventArgs e)
    {
        // this is what itsme86 was suggesting in the comments
        var button = (Button)sender;
        if (tiger.Hawk)
        {
            button.BackColor = Color.DarkSeaGreen;
            label3.Text = "2";
        }
        else
        {
            button.BackColor = Color.PaleGreen;
            label3.Text = "ON";
        }
        if (myport.IsOpen)
        {
            send(new byte[] { 16, 128, 32, 8, 1 });
        }
        tiger.Hawk = !tiger.Hawk;
    }
