        private void TreeView1_Select(object sender, EventArgs e) {
            if (folder != null && System.IO.Directory.Exists(folder)) {
                DirectoryInfo dir = new DirectoryInfo(@folder);
                foreach (FileInfo file in dir.GetFiles()) {
                    Image img = Image.FromFile(file.FullName);
                    Graphics g = Graphics.FromImage(img);
                    g.DrawRectangle(Pens.Black, 0, 0, img.Width, img.Height);
                    imageList.Images.Add(img);
