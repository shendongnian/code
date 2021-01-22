foreach(var text in "abcdefghijklmnopqrstuvwxyz".SplitString(5))
{
	Debug.WriteLine(text);
}
public static IEnumerable&lt;string> SplitString(this string input, int outputStringLength)
{
	var count = 0;
	while (count &lt; input.Length)
	{
		var length = Math.Min(outputStringLength, input.Length - count);
		yield return string.Format("\"{0}\"", input.Substring(count, length));
		count += outputStringLength;
	}
}
