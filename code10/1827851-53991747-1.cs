    using System;
    using System.Windows.Forms;
    namespace WindowsFormsApp1
    {
      public partial class Form1: Form
      {
        public Form1( )
        {
          InitializeComponent( );
        }
        private void button1_Click( object sender, EventArgs e )
        {
          //--> assumes the textBox1.Text contains the file to open...
          var app = new Microsoft.Office.Interop.Word.Application( );
          var doc = app.Documents.Open( textBox1.Text, ReadOnly: true );
          doc.PrintOut( Copies: 1 );
          doc.Close( );
          app.Quit( );
        }
      }
    }
