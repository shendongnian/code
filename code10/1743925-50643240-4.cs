    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FOR i is less than the first image.
            for (int i = 0; i < listView1.SelectedItems.Count; i++)
            {
                //GET filename from listview and store in index.
                _big_fileName = listView1.SelectedItems[i].Text;
                //Create larger instance of image.
                pictureBox1.Image = Image.FromFile(_big_fileName);
                //Fill panel to the width and height of picture box.
                panel1.AutoScrollMinSize = new Size(pictureBox1.Image.Width, pictureBox1.Image.Height);
                _imageIndex = listView1.SelectedIndices[0];
            }
        }
