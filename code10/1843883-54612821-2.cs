            protected override void OnDragDrop(DragEventArgs e) {
            var pb = new PictureBox {
                Image = (Bitmap)e.Data.GetData(typeof(Bitmap))
            };
            pb.Size = pb.Image.Size;
            pb.Location = PointToClient(new Point(e.X - pb.Width / 2, e.Y - pb.Height / 2));
            Controls.Add(pb);
            // deletion here: Controls.Remove(pictureBox1 or pb);
            base.OnDragDrop(e);
        }
