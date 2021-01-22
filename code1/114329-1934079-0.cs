    Match m = Regex.Match(input, @"^:(\w+)(?:!(\w+)@([\w\.]+))? PRIVMSG (#\w+) :(.+)$");
    string nickname = m.Groups[1].Value;
    string ident = m.Groups[2].Value;
    string host = m.Groups[3].Value;
    string channel = m.Groups[4].Value;
    string message = m.Groups[5].Value;
