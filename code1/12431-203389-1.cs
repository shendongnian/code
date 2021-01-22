    // given this enum:
    public enum Foo
    {
        Fizz = 3, 
        Bar = 1,
        Bang = 2
    }
    // this gets Fizz
    var lastFoo = Enum.GetValues(typeof(Foo)).Cast<Foo>().Last();
