    public class Form1 : Form
    { 
        public Form1( )
        {
            Foo f = new Foo( )
            f.DidSomething += f_DidSomething;
            f.DoSomething( );
        }
        void f_DidSomething( object sender, EventArgs e )
        {
            MessageBox.Show( "Event Fired" );
        }
    }
