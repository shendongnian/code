    using Microsoft.Office.Interop.Word;
    namespace ConsoleApp10
    {
      class Program
      {
        static void Main( string[ ] args )
        {
          var app = new Application( );
          var doc = app.Documents.Open( "C:\\some.docx", ReadOnly: true );
          doc.PrintOut( Copies: 3 );  //--> prints to the default printer
          doc.Close( );
          app.Quit( );
        }
      }
    }
