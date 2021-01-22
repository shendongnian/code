    ...
                        pictureBoxCounter[j, i].BackColor = System.Drawing.Color.Transparent;
                        pictureBoxCounter[j, i].Tag = new Point(j, i);
                        panelGame.Controls.Add(pictureBoxCounter[j, i]);
    ...
        private void pictureBoxCounter_Click(object sender, EventArgs e)
        {
          PictureBox box = sender as PictureBox;
          box.BackColor = System.Drawing.Color.Coral;
          Point pos = (Point)box.Tag;
          int row = pos.X;
          int col = pos.Y;
          //etc...
        }
