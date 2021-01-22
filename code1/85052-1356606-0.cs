    bool inWhiteSpace = false;
    string test = "lsg  @~A\tSd 2£R3 ad";
    var chars = (test.ToCharArray())
                    .Where(c => ('a' <= c && c <= 'z') || ('A' <= c && c <= 'Z') || char.IsWhiteSpace(c))
                    .Select(c => {
                        c = char.IsWhiteSpace(c) ? inWhiteSpace ? char.MinValue : ' ' : c;
                        inWhiteSpace = c == ' ' || c == char.MinValue;
                        return c;
                    })
                    .Where(c => c != char.MinValue);
    string result = new string(chars.ToArray());
