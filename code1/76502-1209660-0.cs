    #if CSHARP
    public class Constants {
    #else
    #  define public
    #endif
    // Easy stuff
    public const int FOO = 1;
    public const int BAR = 2;
    // Enums can be done too, but you have to handle the comma
    public enum Color { COLOR_RED, COLOR_GREEN, COLOR_BLUE }
    #if !CSHARP
    ;
    #endif
    #if CSHARP
    }
    #else
    #  undef public
    #endif
