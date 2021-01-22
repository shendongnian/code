        public DrawingCanvas2() : base()
        {
            ComboBox box = new ComboBox();
            AddVisual( box );
            Size outputSize = new Size( 100, 20 );
            box.Measure( outputSize );
            box.Arrange( new Rect( outputSize ) );
            box.UpdateLayout();
            box.Items.Add( "hello1" );
            box.Items.Add( "hello2" );
            box.Items.Add( "hello3" );
            box.SelectedIndex = 1;
        }
