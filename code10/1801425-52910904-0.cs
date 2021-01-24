        void button1_MouseDown(object sender, MouseEventArgs e)
        {           
            Button btn = sender as Button;
            Point offset = new Point(e.X, e.Y);
            btn.Tag = offset;
            btn.DoDragDrop(btn, DragDropEffects.Move);
        }
        void panel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        void panel_DragDrop(object sender, DragEventArgs e)
        {
            Panel pnl = sender as Panel;
            Point pt = pnl.PointToClient(new Point(e.X, e.Y));
            Button btn = e.Data.GetData(typeof(Button)) as Button;
            Point offset = (Point)btn.Tag;
            pt.Offset(-1 * offset.X, -1 * offset.Y);
            btn.Location = pt;       
            btn.Parent = pnl;
        }
        private void btnCount_Click(object sender, EventArgs e)
        {
            label1.Text = "Buttons: " + panel1.Controls.OfType<Button>().ToList().Count.ToString();
            label2.Text = "Buttons: " + panel2.Controls.OfType<Button>().ToList().Count.ToString();
        }
