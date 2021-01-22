    // This KeyValuePair was being used to simulate a tuple. We don't need to simulate a tuple when we have a concrete class.
    class BazAndListOfWrgl {
        Baz Baz { get; set; }
        List<Wrgl> Wrgls { get; set; }
    }
    // Typedefs
    class InnerDictionary : Dictionary<Bar, BazAndListOfWrgl> { }
    class OuterDictionary : Dictionary<Foo, InnerDictionary> { }
    class OuterDictionaryItem : KeyValuePair<Foo, InnerDictionary> { }
    // Example of use
    var myClass = new MyClass<OuterDictionary, OuterDictionaryItem>();
