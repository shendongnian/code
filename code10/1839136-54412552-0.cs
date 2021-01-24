    private void button4_Click(object sender, EventArgs e)
    {
        var regex = new Regex(@"pictureBox(?<num>\d+)");
        foreach (var ctrl in Controls)
        {
            if (ctrl is PictureBox pb)
            {
                if (regex.IsMatch(pb.Name))
                {
                    Debug.WriteLine(pb.Name);
                }
            }
        }
    }
