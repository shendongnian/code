    private void OrderedListButton_Click(object sender, EventArgs e)
    {
        editor.OrderedList();
    }
    private void ImageButton_Click(object sender, EventArgs e)
    {
        using (var ofd = new OpenFileDialog())
        {
            ofd.Filter = "Image files|*.png;*.jpg;*.gif;*.jpeg;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (var image = Image.FromFile(ofd.FileName))
                {
                    editor.InsertImage(image);
                }
            }
        }
    }
