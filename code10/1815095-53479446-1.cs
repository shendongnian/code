    void Main()
    {
        foreach (string word in EnumerateAlphabet())
            Console.WriteLine(word);
    }
    IEnumerable<string> EnumerateAlphabet()
    {
        for (int i = 1; i < 27 * 27 * 27; ++i)
        {
            yield return (GetLetterFromNumber(i / (27 * 27)) + GetLetterFromNumber((i / 27) % 27) + GetLetterFromNumber(i % 27)).TrimLeft();
        }
    }
    string GetLetterFromNumber(int num)
    {
        if (num == 0)
            return " ";
        return ('a' + (num - 1)).ToString();
    }
