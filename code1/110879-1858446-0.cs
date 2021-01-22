    public static void ShouldBe<T>(this T actual, T expected)
{
    
    var frame = new StackTrace(true).GetFrame(1);
    var fileName = frame.GetFileName();
    var lineNumber = frame.GetFileLineNumber() - 1;
    string code = File.ReadLines(fileName).ElementAt(lineNumber).Trim();
    Debug.Assert(actual.Equals(expected), code);
