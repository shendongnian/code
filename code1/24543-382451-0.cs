    foreach (var term in allTerms)
    {
        string pattern = term.ToWord(); // Use /b word boundary regex
        Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
        if (regex.IsMatch(bigTextToSearchForTerms))
        {                    
            result.Add(term);                                        
        }
    }
