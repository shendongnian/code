    using System.Text.RegularExpressions;
    static void Main(string[] args)
    {
        string text = @"*
        | { table_name | view_name | table_alias }.*
        | {
            [ { table_name | view_name | table_alias }. ]
            { column_name | $IDENTITY | $ROWGUID }
            | udt_column_name [ { . | :: } { { property_name | field_name } | method_name ( argument [ ,...n] ) } ]
            | expression
            [ [ AS ] column_alias ]
        }
        | column_alias = expression";
        string pattern = BuildPattern();
        RegexOptions options = RegexOptions.Compiled | RegexOptions.Multiline;
        // solution 1: using a MatchEvaluator(Match) delegate
        string normalizedText = Regex.Replace(text, pattern, GetNormalizedLine, options);
        // solution 2: using replacement groups
        string normalizedText2 = Regex.Replace(text, pattern, "$3$4", options);
        bool areEqual = normalizedText2.Equals(normalizedText);
        Console.Read();
    }
    
    private static string BuildPattern()
    {
        // '|' is special character, needs to be escaped. 
        // Assuming there might be some whitespace after the pipe
        string pipe = @"\|\s*";
        // '{' is special character, needs to be escaped. 
        string bracket = @"\{";
        // remaining text in the line
        string otherText = @".+";
        // using parenthesis () to group the results
        string pattern = $"^(({pipe})({bracket})?)({otherText})$";
        return pattern;
    }
    private static string GetNormalizedLine(Match match)
    {
        GroupCollection groups = match.Groups;
        return $"{groups[3].Value}{groups[4].Value}";
    }
