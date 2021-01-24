    void Main()
    {
        foreach (string word in EnumerateCaveNames())
            Console.WriteLine(word);
    }
    IEnumerable<string> EnumerateCaveNames()
    {
        for (int i = 0; i < 26 * 26 * 26; ++i)
        {
            yield return BuildCaveName(i);
        }
    }
    string BuildCaveName(int caveNum)
    {
        string name = (GetLetterFromNumber(caveNum / (26 * 26)) + GetLetterFromNumber((caveNum / 26) % 26) + GetLetterFromNumber(caveNum % 26)).TrimStart('a');
        if (name == "")
            name = "a";
        return name;
    }
    string GetLetterFromNumber(int num)
    {
        return ('a' + (num - 1)).ToString();
    }
