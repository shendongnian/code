           private void Draw(Point m)
            {
                MainCanvas.Children.Clear();
                
                int mX = (int)m.X;
                int mY = (int)m.Y;
                Ellipse el = new Ellipse();
                el.Width = 15;
                el.Height = 15;
                el.SetValue(Canvas.LeftProperty, (Double)mX);
                el.SetValue(Canvas.TopProperty, (Double)mY);
                el.Fill = Brushes.Black;
    
                MainCanvas.Children.Add(el);
            }
            private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
            {
                Draw(e.GetPosition(MainCanvas));
            }
    
            private void MainCanvas_MouseMove(object sender, MouseEventArgs e)
            {
                Draw(e.GetPosition(MainCanvas));
            }
