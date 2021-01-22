    Point m_start;
    Vector m_startOffset;
    
    private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
    {
        m_start = e.GetPosition(window);
        m_startOffset = new Vector(tt.X, tt.Y);
        grid.CaptureMouse();
    }
    
    private void Grid_MouseMove(object sender, MouseEventArgs e)
    {
        if (grid.IsMouseCaptured)
        {
            Vector offset = Point.Subtract(e.GetPosition(window), m_start);
    
            tt.X = m_startOffset.X + offset.X;
            tt.Y = m_startOffset.Y + offset.Y;
        }
    }
    
    private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
    {
        grid.ReleaseMouseCapture();
    }
