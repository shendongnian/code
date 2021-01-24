    public void Customize(IFixture fixture)
    {
        fixture.Customize<Content>(c => c
            .Without(x => x.Strings)
            .Do(x =>
            {
                x.Strings = fixture.CreateMany<string>().ToList();
            }));
    }
