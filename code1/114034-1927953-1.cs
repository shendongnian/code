    using System;
    using System.IO;
    
    class Test 
    {
        
        public static void Main() 
    {
        string path = @"C:\Test.txt";
        try 
        {
          if( File.Exists( path ) )
          {
            using( StreamReader sr = new StreamReader( path ) )
            {
              while( sr.Peek() >= 0 )
              {
                char c = ( char )sr.Read();
                if( Char.IsNumber( c ) )
                  Console.Write( c );
              }
            }
          }
        } 
        catch (Exception e) 
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
    }
    }
