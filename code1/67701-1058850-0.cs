    var words = new Dictionary<string, string>();
    string text = "I like the environment. The environment is good.";
    text = Regex.Replace(text, "\\w+", m =>
                  {
                      string word = m.Value.ToLower();
                      if (words.ContainsKey(word))
                          return String.Empty;
                      words[word] = word;
                      return m.Value;
                  });
