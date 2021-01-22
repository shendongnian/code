    string s = "THIS IS MY TEXT RIGHT NOW";
    StringBuilder sb = new StringBuilder(s.Length);
    bool capitalize = true;
    foreach (char c in s) {
        sb.Append(capitalize ? Char.ToUpper(c) : Char.ToLower(c));
        capitalize = !Char.IsLetter(c);
    }
    return sb.ToString();
