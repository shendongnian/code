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
 private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Source is Shape shape)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    Point p = e.GetPosition(canvas);
                    Canvas.SetLeft(shape, p.X - shape.ActualWidth / 2);
                    Canvas.SetTop(shape, p.Y - shape.ActualHeight / 2);
                    shape.CaptureMouse();
                }
                else
                {
                    shape.ReleaseMouseCapture();
                }
            }
        }
