    public ICommand ShowSearchCommand
		{
			get { return (ICommand)GetValue(ShowSearchCommandProperty); }
			set { SetValue(ShowSearchCommandProperty, value); }
		}
		public static readonly DependencyProperty ShowSearchCommandProperty =
			DependencyProperty.Register("ShowSearchCommand", typeof(ICommand),
				typeof(SelectionFieldControl),
				new UIPropertyMetadata(OnShowSearchCommandChanged));
		static void OnShowSearchCommandChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
		}
