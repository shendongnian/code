	UIView myBox;
	public override void Draw(CGRect rect)
	{
		base.Draw(rect);
		switch (myBox)
		{
			case null:
				myBox = new UIView(new CGRect(0, 40, rect.Width, 1));
				Control.AddSubview(myBox);
				break;
			default:
				myBox.Frame = new CGRect(0, 40, rect.Width, 1);
				break;
		}
	}
