    List<char> _startingstring_list = startingstring.ToList();
    foreach (char c in word)
                {
                    if (_startingstring_list.Contains(c))
                    {
                        score++;
                        _startingstring_list.Remove(c);
                    }
                    else
                        return null;
                }
