    private async void Button_Generate_Click(object sender, EventArgs e)
    {
        pictureBox1.Visible = true; 
        await Task.Run(() => Download_xl());
        pictureBox1.Visible = false;
    }
