    var words = new HashSet<string>();
    string text = "I like the environment. The environment is good.";
    text = Regex.Replace(text, "\\w+", m =>
                  {
                      string word = m.Value.ToUpperInvariant();
                      if (words.Contains(word))
                          return String.Empty;
                      words.Add(word);
                      return m.Value;
                  });
