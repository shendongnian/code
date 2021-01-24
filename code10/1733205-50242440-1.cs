    public List<Tuple<string, string>> GetUniqueNameOfCharacterXFromList(List<string> input, int maxStringSize = 8) {
        var output = input.Select(a => new Tuple<string, string>(a, a)).ToList();
    
        while (output.Select(a => a.Item2.ToCharArray().Length).Max() > maxStringSize) {
            var letter = output
                .SelectMany(a => a.Item2.ToCharArray().Distinct())
                .GroupBy(a => a)
                .Select(a => new { letter = a.Key, count = a.Count() })
                .OrderByDescending(a => a.letter == ' ')
                .ThenByDescending(a => a.count)
                .First().letter.ToString();
    
            output = output.Select(a => new Tuple<string, string>(a.Item1, (a.Item2.ToCharArray().Length > maxStringSize ? a.Item2.Replace(letter, "") : a.Item2))).ToList();
        }
    
        return output;
    }
