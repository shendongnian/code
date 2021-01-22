        private void MakeCutItem()
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                Image img = item.ImageList.Images[item.ImageIndex];
                Brush overlay = new SolidBrush(Color.FromArgb(128, BackColor));
                Rectangle rect = new Rectangle(new Point(0, 0), item.ImageList.ImageSize);
                using (Graphics g = Graphics.FromImage(img))
                {
                    g.FillRectangle(overlay, rect);
                }
                item.ImageIndex = item.ImageList.Images.Add(img,Color.Empty);
            }
        }
