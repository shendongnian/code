    public void Customize(IFixture fixture)
    {
        var strings = new List<string>();
        fixture.Customize<Content>(c => c
            .With(x => x.Strings, strings));
    }
