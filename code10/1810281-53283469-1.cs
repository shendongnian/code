    RotateTransform _rotateTransform = new RotateTransform(0.0, 24.5, 24.5);
    Duration _rotationSpeed;
    private void CreateRotation()
    {
        _rotationSpeed = new Duration(TimeSpan.FromMilliseconds(222));
	 	menuButtonImage.RenderTransform = _rotateTransform;
    }
	private void rotateMenuForward()
	{
		DoubleAnimation myanimation = new DoubleAnimation(90, _rotationSpeed);
		_rotateTransform.BeginAnimation(RotateTransform.AngleProperty, myanimation);
	}
	private void rotateMenuBackward()
	{
		DoubleAnimation myanimation = new DoubleAnimation(0, _rotationSpeed);
		_rotateTransform.BeginAnimation(RotateTransform.AngleProperty, myanimation);
	}
