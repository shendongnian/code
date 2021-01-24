    var regex = new Regex("(?<B>(\\())*((?<A><)+[^<>]+(?<-A>>)+(?(A)(?!)))+(?<-B>(\\)))*(?(B)(?!))",
        RegexOptions.Multiline | RegexOptions.CultureInvariant | RegexOptions.Compiled);
    var x = (from Match m in regex.Matches("(<x><y><z>)<expr>(<a><b><c>)<d>")
            select new
            {
                result = m.Groups[1].Value.StartsWith("(") ?
                            (new List<string> { "(" }
                                .Concat(m.Groups[2].Captures.Count > 1 ?
                                    (from Capture c in m.Groups[2].Captures select c.Value).ToList()
                                    : new List<string> { m.Groups[2].Value }
                                )
                                .Concat(new List<string> { ")" })
                            )
                            : new List<string> { m.Value }
            }).SelectMany(r => r.result);
