       pop.MouseMove += new MouseEventHandler(pop_MouseMove);
       void pop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                pop.PlacementRectangle = new Rect(new Point(e.GetPosition(this).X,
                    e.GetPosition(this).Y),new Point(200,200));
            
            }
        }
