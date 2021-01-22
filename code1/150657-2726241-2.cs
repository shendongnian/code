    class ChildForm : Form
    {
        public event EventHandler TextChanged;
        public string NewText { get { return textBox1.Text; } }
        void textBox1_TextChanged( object sender, EventArgs e )
        {
            EventHandler del = TextChanged;
            if( del != null )
            {
                del( this, e );
            }
        }
    }
    class MainForm : Form
    {  
        void Foo( )
        {
            using( ChildForm frm = new ChildForm )
            {
                frm.TextChanged += (object sender, EventArgs e) => { label1.Text = frm.NewText; };
                frm.ShowDialog( );
            }
        }
    }
