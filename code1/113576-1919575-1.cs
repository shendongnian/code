    [Test]
    public void Should_make_comma_delimited_list()
    {
        var colors = new List<HasColor>
        {
            new HasColor { Color = "red" },
            new HasColor { Color = "green" },
            new HasColor { Color = "blue" }
        };
        var result = colors.Implode(x => x.Color, ", ");
        Assert.That(result, Is.EqualTo("red, green, blue"));
    }
    public class HasColor
    {
        public string Color { get; set; }
    }
    public static class LinqExtensions
    {
        public static string Implode<T>(this IEnumerable<T> list, Func<T, string> func, string separator)
        {
            return string.Join(separator, list.Select(func).ToArray());
        }
    }
