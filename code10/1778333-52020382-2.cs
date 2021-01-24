    public class Foo
    {
        protected virtual string Name { get; set; } = "Foo";
    }
    public sealed class Bar : Foo
    {
        protected override string Name { get; set; } = "Bar";
    }
