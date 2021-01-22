    /// <summary>
    /// URL encoding class.  Note: use at your own risk.
    /// Written by: Ian Hopkins (http://www.lucidhelix.com)
    /// Date: 2008-Dec-23
    /// (Ported to C# by t3rse (http://www.t3rse.com))
    /// </summary>
    public class UrlHelper
    {
        public static string Encode(string str) {
            var charClass = String.Format("0-9a-zA-Z{0}", Regex.Escape("-_.!~*'()"));
            return Regex.Replace(str, 
                String.Format("[^{0}]", charClass),
                new MatchEvaluator(EncodeEvaluator));
        }
        public static string EncodeEvaluator(Match match)
        {
            return (match.Value == " ")?"+" : String.Format("", Convert.ToInt32(match.Value[0]));
        }
        public static string DecodeEvaluator(Match match) {
            return Convert.ToChar(int.Parse(match.Value.Substring(1), System.Globalization.NumberStyles.HexNumber)).ToString();
        }
        public static string Decode(string str) 
        {
            return Regex.Replace(str.Replace('+', ' '), "%[0-9a-zA-Z][0-9a-zA-Z]", new MatchEvaluator(DecodeEvaluator));
        }
    }
