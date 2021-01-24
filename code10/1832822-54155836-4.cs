	using System;
	using System.Collections.Generic;
	public class Program
	{
		public static void Main()
		{
			const string orig = "aaabbbcccddd";
			int origLen = orig.Length;
			char[] newArr = new char[origLen]; // get max possible spots in arr
			int newCount = 0;
			for(int i = 0; i < origLen; i++)
			{
				bool yes = false;
				for(int j = 0; j < newCount + 1; j++)
				{
					if (newArr[j] == orig[i])
					{    
                        yes = true;
                        break;
					}
				}
				if (!yes)
				{
					newArr[newCount] = orig[i];
					newCount++;
				}
			}
			Console.WriteLine(new string(newArr));
		}
	}
