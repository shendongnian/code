    using System;
    using EnumExtensions;
    
    class Program {
    
    public enum Appearance {
    
      [Text( "left-handed" ) ]
      Left,
    
      [Text( "right-handed" ) ]
      Right,
    
    }//enum
    
    static void Main( string[] args ) {
    
       var appearance = Appearance.Left;
       Console.WriteLine( appearance.ToText() );
    
    }//Main
    
    }//class
