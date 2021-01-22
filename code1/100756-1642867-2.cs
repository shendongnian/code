    class BazPlusListOfWrgl {
        public Baz Baz { get; set; }
        public List<Wrgl> Wrgls { get; set; }
    }
    class DictionaryOfBazPlusListOfWrglKeyedOnBar : Dictionary<Bar, BazPlusListOfWrgl> { }
    class YouGetTheIdeaNow : Dictionary<Foo, DictionaryOfBazPlusListOfWrglKeyedOnBar> { }
    var myClass = new MyClass<YouGetTheIdeaNow>();
