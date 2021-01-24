     public void CreateGraph(Panel pnl)
        {
            PictureBox pb = new PictureBox();
            pb.Dock = DockStyle.Fill;
            pb.BackColor = Color.Bisque;
            pb.Name = "pb";
            pb.Size = new Size(50, 50);
            pb.Location = new Point(20, 20);
            Graphics g = pb.CreateGraphics();
            g.DrawEllipse(new Pen(Color.Red), 0, 0, 50, 50);
            pnl.Controls.Add(pb);
        }
