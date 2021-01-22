      private void button1_Click(object sender, EventArgs e)
      {
         int y = list[0].Location.Y;
         foreach (UserControl2 c in list)
         {
            c.Location = new Point(0, y);
            y += c.Height;
         }
      }
