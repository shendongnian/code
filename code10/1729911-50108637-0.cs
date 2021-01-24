	void removeItem_Click( object sender, RoutedEventArgs e )
	{
		object i = ((FrameworkElement)sender).DataContext;
		( this.DataContext as MyViewModel )?.RemoveItem( i );
	}
