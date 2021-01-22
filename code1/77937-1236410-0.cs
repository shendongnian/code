    namespace WindowsApplication5
    {
        public partial class Form1 : Form
        {
            public Form1( )
            {
                InitializeComponent( );
                AttributeCollection attributes = 
                    TypeDescriptor.GetProperties( mTextBox1 )[ "Foo" ].Attributes;           
                DefaultValueAttribute myAttribute =
                   ( DefaultValueAttribute ) attributes[ typeof( DefaultValueAttribute ) ];
                // prints "440.1"
                MessageBox.Show( "The default value is: " + myAttribute.Value.ToString( ) );
            }
        }
        class mTextBox : TextBox
        {
            private decimal foo;       
            [System.ComponentModel.DefaultValue( 440.1 )]
            public decimal Foo
            {
                get { return foo; }
                set { foo = value; }
            }
        }
    }
