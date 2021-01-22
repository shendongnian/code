	public static class StoryboardServices
	{
		public static DependencyObject GetTarget(Timeline timeline)
		{
			if (timeline == null)
				throw new ArgumentNullException("timeline");
			return timeline.GetValue(TargetProperty) as DependencyObject;
		}
		public static void SetTarget(Timeline timeline, DependencyObject value)
		{
			if (timeline == null)
				throw new ArgumentNullException("timeline");
			timeline.SetValue(TargetProperty, value);
		}
		public static readonly DependencyProperty TargetProperty =
				DependencyProperty.RegisterAttached(
						"Target",
						typeof(DependencyObject),
						typeof(Timeline),
						new PropertyMetadata(null, OnTargetPropertyChanged));
		private static void OnTargetPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			Storyboard.SetTarget(d as Timeline, e.NewValue as DependencyObject);
		}
	}
