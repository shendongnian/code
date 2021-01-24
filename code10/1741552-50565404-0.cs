	public class RibbonView : MyContentView
	{
     //....
      		protected  override void OnSizeAllocated(double width, double height)
		{
			base.OnSizeAllocated(width, height);
            //System.Diagnostics.Debug.Write("width==" + width + "-------------------------------height==" + height);
            var upperLeft = new Point(Content.Margin.Left + Padding.Left, Content.Margin.Top + Padding.Top);
			var upperRight = upperLeft;
			upperRight.X += width - Content.Margin.HorizontalThickness - Padding.HorizontalThickness;
			var lowerLeft = upperLeft;
			lowerLeft.Y += height - Content.Margin.VerticalThickness - Padding.VerticalThickness;
			var lowerRight = upperRight;
			lowerRight.Y = lowerLeft.Y;
			var rotationPoint = new Point()
			{
				X = (lowerRight.X - upperLeft.X) * AnchorX + upperLeft.X,
				Y = (lowerRight.Y - upperLeft.Y) * AnchorY + upperLeft.Y
			};
            RotatedLowerLeftCorner = CalculateRotatedPoint(lowerLeft, rotationPoint);
			RotatedLowerRightCorner = CalculateRotatedPoint(lowerRight, rotationPoint);
			RotatedUpperLeftCorner = CalculateRotatedPoint(upperLeft, rotationPoint);
			RotatedUpperRightCorner = CalculateRotatedPoint(upperRight, rotationPoint);
            System.Diagnostics.Debug.Write("RotatedLowerLeftCorner==" + RotatedLowerLeftCorner + "-------------RotatedLowerRightCorner==" + RotatedLowerRightCorner 
                + "RotatedUpperLeftCorner==" + RotatedUpperLeftCorner +
                "-------------RotatedUpperRightCorner==" + RotatedUpperRightCorner);
			var translationX = Math.Min(Math.Min(RotatedUpperLeftCorner.X, RotatedUpperRightCorner.X), Math.Min(RotatedLowerLeftCorner.X, RotatedLowerRightCorner.X)) * (HorizontalOptions.Alignment == LayoutAlignment.End ? 1 : -1);
			var translationY = Math.Min(Math.Min(RotatedUpperLeftCorner.Y, RotatedUpperRightCorner.Y), Math.Min(RotatedLowerLeftCorner.Y, RotatedLowerRightCorner.Y)) * (VerticalOptions.Alignment == LayoutAlignment.End ? 1 : -1);
            
            //System.Diagnostics.Debug.Write("HorizontalOptions.Alignment========" + (HorizontalOptions.Alignment == LayoutAlignment.End ? 1 : -1)
            //  + "=============VerticalOptions.Alignment========" + (VerticalOptions.Alignment == LayoutAlignment.End ? 1 : -1));
            //Device.BeginInvokeOnMainThread(() =>
            //{
                 //this.TranslateTo(97.8177608193967, -0.27103066889096);
				TranslationX = translationX;
				TranslationY = translationY;
                System.Diagnostics.Debug.Write("TranslationX=="+ TranslationX+ "-------------------------------TranslationY=="+ TranslationY);
			//});
			//CalculateSize(rotationPoint, translationX, translationY);
		}    
        //....
    }
