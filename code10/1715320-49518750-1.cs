    private void button_Click(object sender, EventArgs e)
    {
        // this is what itsme86 was suggesting in the comments
        var button = (Button)sender;
        button.BackColor = tiger.Hawk ? Color.DarkSeaGreen : Color.PaleGreen;
        label3.Text = tiger.Hawk ? "2" : "ON";
        if (myport.IsOpen)
            send(new byte[] { 16, 128, 32, 8, 1 });
        tiger.Hawk = !tiger.Hawk;
    }
