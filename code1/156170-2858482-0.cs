	var dictionary = new ObservableDictionary<int, int>();
	dictionary.PropertyChanged += 
		( sender, args ) => MessageBox.Show( args.PropertyName );
	dictionary.Add( 1, 2 );
	dictionary.Remove( 1 );
