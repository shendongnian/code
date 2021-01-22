    [Test]
    public void int_is_not_an_enumerable()
    {
        var sut = 5;
        Type underlyingType;
        var result = sut.IsEnumerable(out underlyingType);
        result.ShouldBe(false);
        underlyingType.ShouldBeNull();
    }
    [Test]
    public void object_is_not_an_enumerable()
    {
        var sut = new { foo = 1};
        Type underlyingType;
        var result = sut.IsEnumerable(out underlyingType);
        result.ShouldBe(false);
        underlyingType.ShouldBeNull();
    }
