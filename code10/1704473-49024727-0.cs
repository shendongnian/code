	using System;
	using System.Linq;
	using System.IO;
	using System.Text;
	using System.Collections;
	using System.Collections.Generic;
	/**
	 * Auto-generated code below aims at helping you parse
	 * the standard input according to the problem statement.
	 **/
	class Solution
	{
		static void Main(string[] args)
		{
			string N = Console.ReadLine();
			Console.Error.WriteLine(N);
			// Write an action using Console.WriteLine()
			// To debug: Console.Error.WriteLine("Debug messages...");
			int[] array = N.Replace("[", "").Replace("]", "").Split(',').Select(s => int.Parse(s.Trim())).OrderBy(n => n).ToArray();
			
			int lastNum = 0;
			int rangeLength = 0;
			string result = "";
			string bufferResult = "";
			int currentNum = 0;
			for (int i = 0; i <= array.Length; i++) {
				bool flush = false;
				if (i < array.Length) {
					currentNum = array[i];
					if (lastNum == 0) {
						lastNum = currentNum;
						rangeLength = 0;
						bufferResult = "" + lastNum;
					}
					else if (lastNum + 1 == currentNum) {
						lastNum = currentNum;
						rangeLength++;
						bufferResult += "," + lastNum;
					}
					else {
						flush = true;
					}
				}
				else {
					flush = true;
				}
				if (flush) {
					// Flush
					if (result.Length > 0) {
						result += ",";
					}
					if (rangeLength > 1) {
						result += string.Format("{0}-{1}", (lastNum - rangeLength), lastNum);
					}
					else {
						result += bufferResult;
					}
					lastNum = currentNum;
					bufferResult = "" + lastNum;
					rangeLength = 0;
				}
			}
			Console.WriteLine(result);
		}
	}
