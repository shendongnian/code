    private void Form9_Load(object sender, EventArgs e)
    {
        //Reading both  yellow and grey Imgs
        string[] grey = Directory.GetFiles(@"C:\greyImgs");
        string[] yellow = Directory.GetFiles(@"C:\yellowImgs");
        //looping thought the controls in the groupbox which are PictureBoxs
        for (int i = 0; i < groupBox1.Controls.Count; i++)
        {
            // Casting the controls as PictureBox
            PictureBox pic = groupBox1.Controls[i] as PictureBox;
            // Adding the grey imgs to PictureBoxx
            pic.ImageLocation = grey[i];
             // Populating the Dictionary
            List.Add(Path.GetFileNameWithoutExtension(grey[i])[0], new Tuple<PictureBox, string, string>(pic, grey[i], yellow[i]));
        }
    }
