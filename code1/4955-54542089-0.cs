    using AutOIATypeLibrary;
    using AutPSTypeLibrary;
    namespace MyNamespace
    {
        public class Program 
        {
             public AutPS PS = new AutPS();
             public AutOIA OI = new AutOIA();
             static void Main()
            {
                PS.SetConnectionByName("A");
                OI.SetConnectionByName("A");
                 // Gets a string from the presentation space at row 1, col 1, length 5
                PS.GetText(1, 1, 5); 
 
                // Gets the entire screen as a string. parse as needed.
                PS.GetText(1, 1, PS.NumRows * PS.NumCols);
 
                // Searches for a literal string in the presentation space by going forward from your row/col
                PS.SearchText("LiteralString".ToUpper(), PsDir.pcSrchForward, 1, 1);
            }
        }
    }
