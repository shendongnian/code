    [assembly: ExportRenderer(typeof(Button), typeof(CustomButtonRendereriOS))]
    namespace XYZ.iOS.Renderer
    {
      public class CustomButtonRendereriOS : ButtonRenderer
       {
        //To apply gradient background to button
        public override CGRect Frame
        {
            get
            {
                return base.Frame;
            }
            set
            {
                if (value.Width > 0 && value.Height > 0)
                {
                    foreach (var layer in Control?.Layer.Sublayers.Where(layer => layer is CAGradientLayer))
                        layer.Frame = new CGRect(0, 0, value.Width, value.Height);
                }
                base.Frame = value;
            }
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                try
                {
                        var gradient = new CAGradientLayer();
                        gradient.CornerRadius = Control.Layer.CornerRadius = 5;
                        gradient.Colors = new CGColor[]
                        {
                            UIColor.FromRGB(243, 112, 33).CGColor,
                            UIColor.FromRGB(226, 64, 64).CGColor
                        };
                        var layer = Control?.Layer.Sublayers.LastOrDefault();
                        Control?.Layer.InsertSublayerBelow(gradient, layer);
                         
                }
                catch (Exception ex)
                {
                  
                }
              
            }
        }
    }
