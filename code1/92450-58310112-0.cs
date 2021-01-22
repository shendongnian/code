xml
<Canvas Background='Beige'
            Name='canvas'>
        <Rectangle Width='50'
                   Height='50'
                   Fill='LightPink'
                   Canvas.Left='350'
                   Canvas.Top='175'
                   MouseMove='Rectangle_MouseMove' />
    </Canvas>
**Code behind**
c#
private void Rectangle_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is Rectangle rect)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    Point p = e.GetPosition(canvas);
                    Canvas.SetLeft(rect, p.X - rect.Width / 2);
                    Canvas.SetTop(rect, p.Y - rect.Height / 2);
                }
            }
        }
