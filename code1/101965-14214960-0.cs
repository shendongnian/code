    public class A
    {
        public B Property { get; set; }
    }
    public class B
    {
        public C field;
    }
    [Fact]
    public void FactMethodName()
    {
        var exp = (Expression<Func<A, object>>) (x => x.Property.field);
        foreach (var part in exp.ToString().Split('.').Skip(1))
            Console.WriteLine(part);
        // Output:
        // Property
        // field
    }
