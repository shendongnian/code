    protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
     {
        base.OnElementPropertyChanged(sender, e);
        if(e.PropertyName=="BorderColor")
         {
            var color = (Element as GradientButton).BorderColor;
            gradient.Colors = new CGColor[] { ((GradientButton)Element).StartColor.ToCGColor(), color.ToCGColor() };
            shape.StrokeColor = color.ToCGColor();
            shape.FillColor = UIColor.Clear.CGColor;
            gradient.Mask = shape;
            Control.Layer.AddSublayer(gradient);
            Control.Layer.BorderColor = UIColor.Clear.CGColor;
              
         }
    }
