    private void btnSet_Click(object sender, EventArgs e)
    {
        string input = tbInput.Text.Trim(); 
        string[] parts = input.Split(",".ToCharArray()); //assume your coordinates are commas-separated, like "80,100"
        if (parts.Length == 2)
        {
            mouseX = int.Parse(parts[0]);
            mouseY = int.Parse(parts[1]);
            pictureBox1.Refresh(); //Now force picturebox to repaint
        }
    }
