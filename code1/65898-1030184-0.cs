        private void DrawPieChart()
        {
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            Rectangle rect = new Rectangle(0, 0, 300, 300);
            float angle = 0;
            Random random = new Random();
            int sectors = 24;
            int sweep = 360 / sectors;
             g.RotateTransform(90);        //Rotates by 90 degrees
             for(int i=0; i<24;i++)
            {
                Color clr = Color.FromArgb(random.Next(0, 255),random.Next(0, 255), random.Next(0, 255));
                g.FillPie(new SolidBrush(clr), rect, angle, sweep);
                angle += sweep;
            }
            g.Dispose();
        }
