csharp
using System.Linq;
using Xunit;
namespace Q54736241
{
    public class Example
    {
        [Fact]
        public void Example1()
        {
            var strings = new[] { "one", "two", "three", "four", "five" };
            var firstTwo = strings.Take(2);
            Assert.Equal(new[] {"one", "two"}, firstTwo);
        }
    }
}
You'll need to do a bit more work to get the last two. Check out this related question for some examples: https://stackoverflow.com/questions/3453274/using-linq-to-get-the-last-n-elements-of-a-collection
