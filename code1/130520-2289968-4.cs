	private static void DateFormatChanged( DependencyObject obj, DependencyPropertyChangedEventArgs e ) {
		var uc = obj as UserControl1;
		string code;
		if ( null != ( code = e.NewValue as string ) ) {
			uc.datedisplayer.Text = DateTime.Now.ToString( code );
		}
	}
