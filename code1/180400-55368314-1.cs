csharp
public static void AssertAreLinesEqual(string expected, string actual)
{
    using (var expectedReader = new StringReader(expected))
    using (var actualReader = new StringReader(actual))
    {
        while (true)
        {
            var expectedLine = expectedReader.ReadLine();
            var actualLine = actualReader.ReadLine();
            Assert.AreEqual(expectedLine, actualLine);
            if(expectedLine == null || actualLine == null)
                break;
        }
    }
}
Of course, you could also make the method a little more generic and write to return a `bool` instead.
csharp
public static bool AreLinesEqual(string expected, string actual)
{
    using (var expectedReader = new StringReader(expected))
    using (var actualReader = new StringReader(actual))
    {
        while (true)
        {
            var expectedLine = expectedReader.ReadLine();
            var actualLine = actualReader.ReadLine();
            if (expectedLine != actualLine)
                return false;
            if(expectedLine == null || actualLine == null)
                break;
        }
    }
    return true;
}
What surprises me most is that there isn't a method like this included in any unit testing framework I've used.
