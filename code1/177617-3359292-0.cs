    namespace ConsoleApplication1
    {
        using System;
    
        class Program
        {
            static void Main( string[] args )
            {
                var laterDate = new DateTime( 2006, 7, 6, 12, 1, 0 );
                var earlyDate = new DateTime( 1970, 1, 1, 0, 0, 0 );
                var diff = laterDate.ToUniversalTime().Subtract( earlyDate.ToUniversalTime() );
                var seconds = diff.TotalSeconds;
            }
        }
    }
