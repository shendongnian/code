        zg1.MouseClick+=new MouseEventHandler(zg1_MouseClick3);
       
        private void zg1_MouseClick3(object sender, MouseEventArgs e)
        {
            PointF pt = (PointF)e.Location;
            double x,y;
            ((ZedGraphControl)sender).MasterPane[0].ReverseTransform(pt, out x, out y);
            // Do something with X and Y
        }
