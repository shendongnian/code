    class Program {
    	static void Main(string[] args) {
    		// setup some test expressions
    		List<string> searchExpressions = new List<string>(new string[] { 
    			"engine 2009", 
    			"\"san francisco\"     hotel december xyz", 
    			"stuff* \"in miami\"   1234 ", 
    			"something or \"something else\""
    		});
    
    		// display and parse each expression
    		foreach (string searchExpression in searchExpressions) {
    			Console.WriteLine(string.Concat(
    				"User Input: ", searchExpression, 
    				"\r\n\tSql Expression: ", ParseSearchExpression(searchExpression), 
    				"\r\n"));
    		}
    
    		Console.ReadLine();
    
    	}
    
    private static string ParseSearchExpression(string searchExpression) {
        // replace all 'spacecharacters' that exists within quotes with character 0
        string temp = Regex.Replace(searchExpression, @"""[^""]+""", (MatchEvaluator)delegate(Match m) {
            return Regex.Replace(m.Value, @"[\s]", "\x00");
        });
        // split string on any spacecharacter (thus: quoted items will not be splitted)
        string[] tokens = Regex.Split(temp, @"[""\s]+", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);
        // generate result
        StringBuilder result = new StringBuilder();
        string tokenLast = string.Empty;
        foreach (string token in tokens) {
            if (token.Length > 0) {
                if ((token.Length > 0) && (!token.Equals("AND", StringComparison.OrdinalIgnoreCase))) {
                    if (result.Length > 0) {
                        result.Append(tokenLast.Equals("OR", StringComparison.OrdinalIgnoreCase) ? " OR " : " AND ");
                    }
                    result.Append("\"").Append(token.Replace("\"", "\"\"").Replace("\x00", " ")).Append("\"");
                }
                tokenLast = token;
            }
        }
        if (result.Length > 0) {
            result.Insert(0, "(").Append(")");
        }
        return result.ToString();
    }
    }
