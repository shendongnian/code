    Dictionary<string, int> words = new Dictionary<string, int>();
    string input = "The woods decay the woods decay and fall.";
    foreach (Match word in Regex.Matches(input, @"\w+", RegexOptions.ECMAScript))
    {
        if (!words.ContainsKey(word.Value))
        {
            words.Add(word.Value, 1);
        }
        else
        {
            words[word.Value]++;
        }
    }
