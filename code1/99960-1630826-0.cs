      void Window1_MouseDown(object sender, MouseButtonEventArgs e)
            {
                Point mousePosition = (Point)e.MouseDevice.GetPosition(this);
                myPolyline.Points.Add(mousePosition);
            }
    
