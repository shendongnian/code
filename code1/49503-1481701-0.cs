    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> InPages<T>(this IEnumerable<T> enumOfT, int pageSize)
        {
            if (null == enumOfT) throw new ArgumentNullException("enumOfT");
            if (pageSize < 1) throw new ArgumentOutOfRangeException("pageSize");
            var enumerator = enumOfT.GetEnumerator();
            while (enumerator.MoveNext())
            {
                yield return InPagesInternal(enumerator, pageSize);
            }
        }
        private static IEnumerable<T> InPagesInternal<T>(IEnumerator<T> enumeratorOfT, int pageSize)
        {
            var count = 0;
            while (true)
            {
                yield return enumeratorOfT.Current;
                if (++count >= pageSize) yield break;
                if (false == enumeratorOfT.MoveNext()) yield break;
            }
        }
        public static string Join<T>(this IEnumerable<T> enumOfT, object separator)
        {
            var sb = new StringBuilder();
            if (enumOfT.Any())
            {
                sb.Append(enumOfT.First());
                foreach (var item in enumOfT.Skip(1))
                {
                    sb.Append(separator).Append(item);
                }
            }
            return sb.ToString();
        }
    }
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test()
        {
            // Arrange
            var ints = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var expected = new[]
            {
                new[] { 1, 2, 3 },
                new[] { 4, 5, 6 },
                new[] { 7, 8, 9 },
                new[] { 10      },
            };
            // Act
            var pages = ints.InPages(3);
            // Assert
            var expectedString = (from x in expected select x.Join(",")).Join(" ; ");
            var pagesString = (from x in pages select x.Join(",")).Join(" ; ");
            Console.WriteLine("Expected : " + expectedString);
            Console.WriteLine("Pages    : " + pagesString);
            Assert.That(pagesString, Is.EqualTo(expectedString));
        }
    }
