    private void Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			moving = true;
		}
		private void Button_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			moving = false;
		}
		private void Button_PreviewMouseMove(object sender, MouseEventArgs e)
		{
			if (moving)
			{
				Canvas.SetTop(this, e.GetPosition(Parent as Canvas).Y);
				Canvas.SetLeft(this, e.GetPosition(Parent as Canvas).X);
			}
		}
