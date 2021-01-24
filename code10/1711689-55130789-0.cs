    	if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
			{
				var button = MKUserTrackingButton.FromMapView(map);
				button.Layer.BackgroundColor = UIColor.White.CGColor;
				button.Layer.BorderColor = UIColor.FromRGB(0, 0, 127).CGColor;
				button.Layer.BorderColor = UIColor.White.CGColor;
				button.Layer.BorderWidth = 1;
				button.Layer.CornerRadius = 5;
				button.TranslatesAutoresizingMaskIntoConstraints = false;
				View.AddSubview(button); 
				NSLayoutConstraint.ActivateConstraints(new NSLayoutConstraint[]{
					button.BottomAnchor.ConstraintEqualTo(View.BottomAnchor, -10),
					button.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor, -10)
				});
			}
