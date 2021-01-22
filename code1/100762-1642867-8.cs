    // This KeyValuePair was being used to simulate a tuple. We don't need to simulate a tuple when we have a concrete class.
    class BazAndListOfWrgl {
        Baz Baz { get; set; }
        List<Wrgl> Wrgls { get; set; }
    }
    // Simple typedef.
    class BazAndListOfWrglDictionary : Dictionary<Bar, BazAndListOfWrgl> { }
