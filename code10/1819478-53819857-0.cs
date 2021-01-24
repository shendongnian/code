    [Fact]
    public void CustomizeMany()
    {
        var fixture = new Fixture();
        var items = fixture.Build<MyClass>()
            .With(x => x.EvenNumber, (int number) => number * 2)
            .CreateMany(1000)
            .ToArray();
        
        Assert.All(items, item => Assert.Equal(0, item.EvenNumber % 2));
    }
    public class MyClass
    {
        public int EvenNumber { get; set; }
    }
