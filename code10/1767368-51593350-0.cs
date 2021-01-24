    public static string RemoveCharactersThatOccurNumberOfTimes(string s, int numberOfOccurances)
    {
        var charactersToBeRemoved = s.GroupBy(c => c).Where(g => g.Count() == numberOfOccurances).Select(g => g.Key);
		return String.Join("", s.Where(c => !charactersToBeRemoved.Contains(c)));
    }
