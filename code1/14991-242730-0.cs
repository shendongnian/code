        string input = "foo and bar or blop";
        string result = Regex.Replace(input, @"([a-z0-9]+)", match => {
                string word = match.Groups[1].Value;
                switch (word) {
                    case "and":
                    case "not":
                    case "or":
                        return word;
                    default:
                        return "\"" + word + "\"";
                }
            });
