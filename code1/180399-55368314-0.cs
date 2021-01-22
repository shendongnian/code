csharp
public static void AssertAreLinesEqual(string expected, string actual)
{
    using (var expectedReader = new StringReader(expected))
    using (var actualReader = new StringReader(actual))
    {
        var expectedLine = expectedReader.ReadLine();
        var actualLine = actualReader.ReadLine();
        Assert.AreEqual(expectedLine, actualLine);
    }
}
Of course, you could also make the method a little more generic and write to return a `bool` instead.
csharp
public static bool AreLinesEqual(string expected, string actual)
{
    using (var expectedReader = new StringReader(expected))
    using (var actualReader = new StringReader(actual))
    {
        var expectedLine = expectedReader.ReadLine();
        var actualLine = actualReader.ReadLine();
        if (expectedLine != actualLine)
            return false;
    }
    return true;
}
What surprises me most is that there isn't a method like this included in any unit testing framework I've used.
