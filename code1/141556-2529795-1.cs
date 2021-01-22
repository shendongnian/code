            private bool displayRectangle = false;
       
            private void panel1_MouseClick(object sender, MouseEventArgs e)
            {
                displayRectangle = true;
                panel1.Invalidate(false);
            }
    
            private void panel1_Paint(object sender, PaintEventArgs e)
            {
                if (displayRectangle)
                {
                    using (Pen p = new Pen(Color.Black, 2))
                    {
                        e.Graphics.DrawRectangle(p, 100, 100, 100, 200);
                    }
                }
            }
