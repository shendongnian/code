    private void listView1_DragDrop(object sender, DragEventArgs e)
    {
        if (0 < listView1.SelectedItems.Count)
        {
            var item = listView1.SelectedItems[0];
            Image img1 = imageList1.Images[item.ImageIndex];
            pictureBox1.Image = img1;
        }
    }
