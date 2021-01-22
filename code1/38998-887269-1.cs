    using System;
    using System.IO; 
    
    
    namespace DelegateExample
    {
      class Program
      {
        public delegate void PrintDelegate ( string s );
    
        public static void Main ()
        {
          PrintDelegate delFileWriter = new PrintDelegate ( PrintFoFile );
          PrintDelegate delConsoleWriter = new PrintDelegate ( PrintToConsole);
          Console.WriteLine ( "PRINT FIRST TO FILE by passing the print delegate -- DisplayMethod ( delFileWriter )" );
    
          DisplayMethod ( delFileWriter );      //prints to file
          Console.WriteLine ( "PRINT SECOND TO CONSOLE by passing the print delegate -- DisplayMethod ( delConsoleWriter )" );
          DisplayMethod ( delConsoleWriter ); //prints to the console
          Console.WriteLine ( "Press enter to exit" );
          Console.ReadLine ();
    
        }
    
        static void PrintFoFile ( string s )
        {
          StreamWriter objStreamWriter = File.CreateText( AppDomain.CurrentDomain.BaseDirectory.ToString() + "file.txt" );
          objStreamWriter.WriteLine ( s );
          objStreamWriter.Flush ();
          objStreamWriter.Close ();
        }
    
    
        public static void DisplayMethod ( PrintDelegate delPrintingMethod )
        { 
          delPrintingMethod( "The stuff to print regardless of where it will go to" ) ;
        }
    
        static void PrintToConsole ( string s )
        {
          Console.WriteLine ( s );    
        } //eof method 
      } //eof classs 
    } //eof namespace 
 
