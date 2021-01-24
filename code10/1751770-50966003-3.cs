    [assembly: ExportRenderer(typeof(RoundedBoxView), typeof(RoundedBoxViewRenderer))]
    namespace TestApp.iOS
    {
	public class RoundedBoxViewRenderer: BoxRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
		{
			base.OnElementChanged(e);
			if (Element != null)
			{
				Layer.MasksToBounds = true;
				UpdateCornerRadius(e.NewElement as RoundedBoxView);
			}
		}
		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
			
			if (e.PropertyName == CircleView.WidthProperty.PropertyName || e.PropertyName == CircleView.HeightProperty.PropertyName)
			{
				UpdateCornerRadius(Element as RoundedBoxView);
			}
		}
		void UpdateCornerRadius(RoundedBoxView box)
		{
			Layer.CornerRadius = (nfloat)(box.CornerRadius);
			
			CGRect bounds = new CGRect(0, 0, box.Width, box.Width);
			Layer.Bounds = bounds;
			Layer.Frame = bounds;
		}
	}
    
