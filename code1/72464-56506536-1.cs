    public class MyClass
    {
        /// <summary>
        /// Localization root for this class.
        /// </summary>
        static ILine localization = LineRoot.Global.Type<MyClass>();
    
        /// <summary>
        /// Localization key "Ok" with a default string, and couple of inlined strings for two cultures.
        /// </summary>
        static ILine ok = localization.Key("Success")
                .Text("Success")
                .fi("Onnistui")
                .sv("Det funkar");
    
        /// <summary>
        /// Localization key "Error" with a default string, and couple of inlined ones for two cultures.
        /// </summary>
        static ILine error = localization.Key("Error")
                .Format("Error (Code=0x{0:X8})")
                .fi("Virhe (Koodi=0x{0:X8})")
                .sv("Sönder (Kod=0x{0:X8})");
    
        public void DoOk()
        {
            Console.WriteLine( ok );
        }
    
        public void DoError()
        {
            Console.WriteLine( error.Value(0x100) );
        }
    }
