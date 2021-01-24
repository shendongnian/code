    string rsaKey = @"----RSAKEY----
    AWEACAWE123213AWEAWECAWE!AWEAWE
    AWEAWEAWEAWEAWEQEAWEAWHYTAWEAAA
    ----END RSA KEY ----";
    rsaKey = rsaKey.Replace("\r\n", "\r");
    var kvpAttribute = new KeyValuePair<string,string>("rsaKey", rsaKey);
