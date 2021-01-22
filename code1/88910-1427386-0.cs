    using System;
    
    namespace CountOcc
    {
     class Program
     {
      public static void Main(string[] args)
      {
       int         StartPos; // Current pos in file.
       
       System.IO.StreamReader sr = new System.IO.StreamReader( "c:\\file.txt" );
       String Str = sr.ReadToEnd();
       
       int Count = 0;
       StartPos = 0;
       do
       {
        StartPos = Str.IndexOf( "Services", StartPos );
        if ( StartPos >= 0 )
        {
         StartPos++;
         Count++;
        }
       } while ( StartPos >= 0 );
       
       Console.Write("File contained " + Count + " occurances");
       Console.ReadKey(true);
      }
     }
    }
