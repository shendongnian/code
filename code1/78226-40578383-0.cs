        Point mousedownpoint = Point.Empty;
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            mousedownpoint = new Point(e.X, e.Y);
        }
        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (mousedownpoint.IsEmpty)
                return;
            Form f = sender as Form;
            f.Location = new Point(f.Location.X + (e.X - mousedownpoint.X), f.Location.Y + (e.Y - mousedownpoint.Y));
        
        }
        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            mousedownpoint = Point.Empty;
        }
