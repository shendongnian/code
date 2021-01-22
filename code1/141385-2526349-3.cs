    //At the top
    using StringReplacements = System.Collections.Generic.Dictionary<string,string>;
    //In your function
    var replacements = new StringReplacements() { {"(", "-"}, {")", ""} };
    var result = "foobar(baz2)".ReplaceMany(replacements);
