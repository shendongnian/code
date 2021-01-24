    class Dummy
    {
        public int Value { get; set; }
    }
    ...
    PropertyInfo prop = typeof(Dummy).GetProperty("Value");
    Func<Dummy, object> getter = ResolveGetter<Dummy>(prop);
    Action<Dummy, object> setter = ResolveSetter<Dummy>(prop);
    Dummy d = new Dummy { Value = 123 };
    Assert.AreEqual(123, getter(d));
    setter(d, 321);
    Assert.AreEqual(321, d.Value);
