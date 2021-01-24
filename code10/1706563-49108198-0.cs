    var button = (CustomButton)Control.Element;
	using (var image = GetScaleDrawable(Resources.GetDrawable(button.CustomImage.Split('.')[0]),
        (int)button.WidthRequest, 
        (int)button.HeightRequest))
	{
		if (button.ImageTintColor != Xamarin.Forms.Color.Default)
			image.SetColorFilter(button.ImageTintColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
		this.Control.SetPadding(0, 0, 0, 0);
		this.Control.SetCompoundDrawables(null, image, null, null);
	}
