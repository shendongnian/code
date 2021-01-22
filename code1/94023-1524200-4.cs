        private void TreeView1_Select(object sender, EventArgs e) {
            if (folder != null && System.IO.Directory.Exists(folder)) {
                DirectoryInfo dir = new DirectoryInfo(@folder);
                foreach (FileInfo file in dir.GetFiles()) {
                    Image img = new Bitmap(Image.FromFile(file.FullName));
                    using (Graphics g = Graphics.FromImage(img)){
                        g.DrawRectangle(Pens.Black, 0, 0, img.Width - 2, img.Height - 2);
                    }
                    imageList.Images.Add(img);
