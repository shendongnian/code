	static void Main(string[] args)
	{
		// Build string of n consecutive "ab"
		int n = 1000;
        Console.WriteLine("N: " + n);
		char[] c = new char[n];
		for (int i = 0; i < n; i+=2)
			c[i] = 'a';
		for (int i = 1; i < n; i += 2)
			c[i] = 'b';
		string s = new string(c);
		Stopwatch stopwatch;
		// Make sure everything is loaded
		s.CleanNumberString();
		s.Replace("a", "");
		s.UnsafeRemove();
		// Tests to remove all 'a' from the string
		// Unsafe remove
		stopwatch = Stopwatch.StartNew();
		string a1 = s.UnsafeRemove();
		stopwatch.Stop();
		Console.WriteLine("Unsafe remove:\t" + stopwatch.Elapsed.TotalMilliseconds + "ms");
		// Extension method
		stopwatch = Stopwatch.StartNew();
		string a2 = s.CleanNumberString();
		stopwatch.Stop();
		Console.WriteLine("Clean method:\t" + stopwatch.Elapsed.TotalMilliseconds + "ms");
		// String replace
		stopwatch = Stopwatch.StartNew();
		string a3 = s.Replace("a", "");
		stopwatch.Stop();
		Console.WriteLine("String.Replace:\t" + stopwatch.Elapsed.TotalMilliseconds + "ms");
		// Make sure the returned strings are identical
		Console.WriteLine(a1.Equals(a2) && a2.Equals(a3));
		Console.ReadKey();
	}
	public static string CleanNumberString(this string s)
	{
		char[] letters = new char[s.Length];
		int count = 0;
		for (int i = 0; i < s.Length; i++)
			if (s[i] == 'b')
				letters[count++] = 'b';
		return new string(letters.SubArray(0, count));
	}
	public static T[] SubArray<T>(this T[] data, int index, int length)
	{
		T[] result = new T[length];
		Array.Copy(data, index, result, 0, length);
		return result;
	}
	// Taken from https://stackoverflow.com/a/2183442/6923568
	public static unsafe string UnsafeRemove(this string s)
	{
		int len = s.Length;
		char* newChars = stackalloc char[len];
		char* currentChar = newChars;
		for (int i = 0; i < len; ++i)
		{
			char c = s[i];
			switch (c)
			{
				case 'a':
					continue;
				default:
					*currentChar++ = c;
					break;
			}
		}
		return new string(newChars, 0, (int)(currentChar - newChars));
	}
