    private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Point pt = new Point(e.X, e.Y);
            int index = listBox1.IndexFromPoint(pt);
            
            if (index <= -1)
            {
                listBox1.SelectedItems.Clear();
            }
        }
