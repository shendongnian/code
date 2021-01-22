    var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                   {
                       { "IPHone", "TCP/IP honing tools" }
                   };
    Console.WriteLine(dict["iPhone"]); // "TCP/IP honing tools"
    Console.WriteLine( ??? ); // "IPHone"
