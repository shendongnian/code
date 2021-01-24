    private void Right_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
    {
     
        var x = this.RightRotateTransform.CenterX - e.Position.X;
        var y = this.RightRotateTransform.CenterY - e.Position.Y;
                 
        double a1 = Math.Atan(y / x);
        double a2 = Math.Atan((e.Delta.Translation.Y - y) / (x - e.Delta.Translation.X));
     
        this.RightRotateTransform.Angle += a1 - a2;
    }
