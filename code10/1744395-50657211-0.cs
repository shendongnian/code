    public void MyMouseOver()
    {
        Ellipse myShape = new Ellipse() { Width = 200, Height = 100, Stroke = Brushes.Yellow, };
        MyCanvas.Children.Add(myShape);
        Canvas.SetTop(myShape,10);
        Canvas.SetLeft(myShape,10);
        myShape.MouseEnter += MyShape_MouseEnter;
        myShape.MouseLeave += MyShape_MouseLeave;
    }
    private void MyShape_MouseLeave(object sender, MouseEventArgs e)
    {
        ((Ellipse)sender).RenderTransform = new ScaleTransform(1, 1);    // return scale to normal
    }
    private void MyShape_MouseEnter(object sender, MouseEventArgs e)
    {
        ((Ellipse)sender).RenderTransform = new ScaleTransform(1.1, 1.1, Width / 2, Height / 2);
    }
