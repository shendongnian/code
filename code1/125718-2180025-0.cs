    public static class StringExtensions
    {
    
        public Dictionary<string, string> ExtractQueryStringValues( this string target )
        {
    
            string queryString = target.Split (target.IndexOf ('?') + 1);
    
            string[] keyvaluePairs = queryString.Split ('&');
    
            Dictionary<string, string> result = new Dictionary<string, string>();
    
            foreach( string pair in keyvaluePairs )
            {
                 var tmp = pair.Split ('=');
    
                 result.Add (tmp[0], tmp[1]);
            }
    
            return result;
    
        }
    
    }
