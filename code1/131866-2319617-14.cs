    [Test]
    public void List_is_enumerable()
    {
        var sut = new List<int>();
        Type underlyingType;
        var result = sut.IsEnumerable(out underlyingType);
        result.ShouldBeTrue();
        underlyingType.ShouldBe(typeof(int));
    }
//
    [Test]
    public void Yield_return_is_enumerable()
    {
        var sut = Yielded();
        Type underlyingType;
        var result = sut.IsEnumerable(out underlyingType);
        result.ShouldBeTrue();
        underlyingType.ShouldBe(typeof(int));
    }
    private IEnumerable<int> Yielded()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return i;
        }
    }
