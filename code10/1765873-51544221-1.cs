    var foo = new Foo();
    var dictionary =
        new Dictionary<dynamic, string>
        {
            { 1, "One" },     // key is numeric
            { "Two", "Two" }, // key is string
            { foo, "Foo" }    // key is object
        };
    dictionary.ContainsKeyIgnoreCase("two");     // Returns true
    dictionary.ContainsKeyIgnoreCase("TwO");     // Returns true
    dictionary.ContainsKeyIgnoreCase("aBc");     // Returns false
    dictionary.ContainsKeyIgnoreCase(1);         // Returns true
    dictionary.ContainsKeyIgnoreCase(2);         // Returns false
    dictionary.ContainsKeyIgnoreCase(foo);       // Returns true
    dictionary.ContainsKeyIgnoreCase(new Foo()); // Returns false
