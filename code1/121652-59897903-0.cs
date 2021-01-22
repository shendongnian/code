c#
private Action _clickAction;
private int _clickCount;
private void Grid_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
{
	Debug.WriteLine("Button Click Occurred");
	_clickCount++;
	if (_clickCount == 1)
	{
		_clickAction = SingleClick;
	}
	if (_clickCount > 1)
	{
		_clickAction = DoubleClick;
	}
	if (_clickCount == 1)
	{
		Task.Delay(200)
			.ContinueWith(t => _clickAction(), TaskScheduler.FromCurrentSynchronizationContext())
			.ContinueWith(t => { _clickCount = 0; });
	}
}
private void DoubleGridClick()
{
	Debug.WriteLine("Double Click");
}
private void SingleGridClick()
{
	Debug.WriteLine("Single Click");
}
