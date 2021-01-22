    Point m_start;
        Vector m_startOffset;
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = sender as Grid;
            TranslateTransform translate = element.RenderTransform as TranslateTransform;
            m_start = e.GetPosition(gridHost);
            m_startOffset = new Vector(translate.X, translate.Y);
            element.CaptureMouse();
        }
        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            FrameworkElement element = sender as Grid;
            TranslateTransform translate = element.RenderTransform as TranslateTransform;
            if (element.IsMouseCaptured)
            {
                Vector offset = Point.Subtract(e.GetPosition(gridHost), m_start);
                translate.X = m_startOffset.X + offset.X;
                translate.Y = m_startOffset.Y + offset.Y;
            }
        }
        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = sender as Grid;
            element.ReleaseMouseCapture();
        }
