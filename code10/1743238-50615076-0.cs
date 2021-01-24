    private void addlabel_MouseClick(object sender, MouseEventArgs e)
    {
        Image File;
        OpenFileDialog f = new OpenFileDialog();
        f.Filter = "Image files (*.jpg, *.png) | *.jpg; *.png";
    
        if (f.ShowDialog() == DialogResult.OK)
        {
            File = Image.FromFile(f.FileName);
            pictureBox3.Image = File;
            pictureBox3.Image.Save(specific_folder + "\\" + f.SafeFileName);
        }
    }
