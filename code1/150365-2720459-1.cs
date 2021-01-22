Regex Test time: 340,3461
RemoveMultiSpace Test time: 0,3123
[TestFixture]
public class RegExSpaceReplaceTest
{
	private static readonly Regex regex_select_all_multiple_whitespace_chars = new Regex(@"\s+", RegexOptions.Compiled);
	[Test]
	public void Test()
	{
		string startString = "A B  C   D    E     F      A B  C   D    E     F      A B  C   D    E     F      A B  C   D    E     F      A B  C   D    E     F      A B  C   D    E     F      A B  C   D    E     F      A B  C   D    E     F      A B  C   D    E     F      A B  C   D    E     F      ";
		string cleanString;
		Trace.WriteLine("Regex Test start");
		int count = 10000;
		Stopwatch timer = new Stopwatch();
		timer.Start();
		for (int i = 0; i < count; i++)
		{
			cleanString = regex_select_all_multiple_whitespace_chars.Replace(startString, " ");
		}
		var elapsed = timer.Elapsed;
		Trace.WriteLine("Regex Test end");
		Trace.WriteLine("Regex Test time: " + elapsed.TotalMilliseconds);
		Trace.WriteLine("RemoveMultiSpace Test start");
		timer = new Stopwatch();
		timer.Start();
		cleanString = RemoveMultiSpace(startString);
		elapsed = timer.Elapsed;
		Trace.WriteLine("RemoveMultiSpace Test end");
		Trace.WriteLine("RemoveMultiSpace Test time: " + elapsed.TotalMilliseconds);
	}
	public string RemoveMultiSpace(string test)
	{
		var words = test.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
		return string.Join(" ", words);
	}
}
