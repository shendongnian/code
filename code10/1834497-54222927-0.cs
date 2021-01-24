	string[] text = File.ReadAllLines("file.csv", Encoding.Default);
	string[] datArr;
	string tmpStr;
	foreach (string line in text)
	{
	  ParseString(line, ",", "!@@@@!", out datArr, out tmpStr)
	  foreach(string s in datArr)
	  {
		Console.WriteLine(s);
	  }
	}
	Console.ReadKey();
		
	private static void ParseString(string inputString, string origDelim, string newDelim, out string[] retArr,	out string retStr)
	{
		string tmpStr = inputString;
		retArr = new[] {""};
		retStr = "";
		if (!string.IsNullOrWhiteSpace(tmpStr))
		{
			//If there is only one Quote character in the line, ignore/remove it:
			if (tmpStr.Count(f => f == '"') == 1)
				tmpStr = tmpStr.Replace("\"", "");
			string[] tmpArr = tmpStr.Split(new[] {origDelim}, StringSplitOptions.None);
			var inQuote = 0;
			StringBuilder lineToWrite = new StringBuilder();
			foreach (var s in tmpArr)
			{
				if (s.Contains("\""))
					inQuote++;
				switch (inQuote)
				{
					case 1:
						//Begin quoted text
						lineToWrite.Append(lineToWrite.Length > 0
							? newDelim + s.Replace("\"", "")
							: s.Replace("\"", ""));
						if (s.Length > 4 && s.Substring(0, 2) == "\"\"" && s.Substring(s.Length - 2, 2) != "\"\"")
						{
							//if string has two quotes at the beginning and is > 4 characters and the last two characters are NOT quotes,
							//inquote needs to be incremented.
							inQuote++;
						}
						else if ((s.Substring(0, 1) == "\"" && s.Substring(s.Length - 1, 1) == "\"" &&
								  s.Length > 1) || (s.Count(x => x == '\"') % 2 == 0))
						{
							//if string has more than one character and both begins and ends with a quote, then it's ok and counter should be reset.
							//if string has an EVEN number of quotes, it should be ok and counter should be reset.
							inQuote = 0;
						}
						else
						{
							inQuote++;
						}
						break;
					case 2:
						//text between the quotes
						//If we are here the origDelim value was found between the quotes
						//include origDelim so there is no data loss.
						//Example quoted text: "Dr. Mario, Sr, MD";
						//      ", Sr" would be handled here
						//      ", MD" would be handled in case 3 end of quoted text.
						lineToWrite.Append(origDelim + s);
						break;
					case 3:
						//End quoted text
						//If we are here the origDelim value was found between the quotes
						//and we are at the end of the quoted text
						//include origDelim so there is no data loss.
						//Example quoted text: "Dr. Mario, MD"
						//      ", MD" would be handled here.
						lineToWrite.Append(origDelim + s.Replace("\"", ""));
						inQuote = 0;
						break;
					default:
						lineToWrite.Append(lineToWrite.Length > 0 ? newDelim + s : s);
						break;
				}
			}
			if (lineToWrite.Length > 0)
			{
					retStr = lineToWrite.ToString();
					retArr = tmpLn.Split(new[] {newDelim}, StringSplitOptions.None);
				
			}
		}
	}
