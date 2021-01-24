    RotateTransform _rotateTransform = new RotateTransform(0.0, 24.5, 24.5);
    private void CreateRotation()
    {
	 	menuButtonImage.RenderTransform = _rotateTransform;
    }
	private void rotateMenuForward()
	{
		DoubleAnimation myanimation = new DoubleAnimation(90, new Duration(TimeSpan.FromMilliseconds(222)));
		_rotateTransform.BeginAnimation(RotateTransform.AngleProperty, myanimation);
	}
	private void rotateMenuBackward()
	{
		DoubleAnimation myanimation = new DoubleAnimation(0, new Duration(TimeSpan.FromMilliseconds(222)));
		_rotateTransform.BeginAnimation(RotateTransform.AngleProperty, myanimation);
	}
