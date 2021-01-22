        public enum BrushTypes
        {
            Solid,
            Gradient
        }
        public BrushTypes BrushType
        {
            get { return ( BrushTypes )GetValue( BrushTypeProperty ); }
            set { SetValue( BrushTypeProperty, value ); }
        }
        public static readonly DependencyProperty BrushTypeProperty = 
                   DependencyProperty.Register( "BrushType", 
                                                typeof( BrushTypes ), 
                                                typeof( MyClass ) );
