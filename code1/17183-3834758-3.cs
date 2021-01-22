    public static class StringEntentions {
    		/// <summary>
    		/// Indicates whether the current string matches the supplied wildcard pattern.  Behaves the same
    		/// as VB's "Like" Operator.
    		/// </summary>
    		/// <param name="s">The string instance where the extension method is called</param>
    		/// <param name="wildcardPattern">The wildcard pattern to match.  Syntax matches VB's Like operator.</param>
    		/// <returns>true if the string matches the supplied pattern, false otherwise.</returns>
    		/// <remarks>See http://msdn.microsoft.com/en-us/library/swf8kaxw(v=VS.100).aspx</remarks>
    		public static bool IsLike(this string s, string wildcardPattern) {
    			if (s == null || String.IsNullOrEmpty(wildcardPattern)) return false;
    			// turn into regex pattern, and match the whole string with ^$
    			var regexPattern = "^" + Regex.Escape(wildcardPattern) + "$";
    			// add support for ?, #, *, [], and [!]
    			regexPattern = regexPattern.Replace(@"\[!", "[^")
                                           .Replace(@"\[", "[")
                                           .Replace(@"\]", "]")
                                           .Replace(@"\?", ".")
                                           .Replace(@"\*", ".*")
                                           .Replace(@"\#", @"\d");
    
    			var result = false;
    			try {
    				result = Regex.IsMatch(s, regexPattern);
    			}
    			catch (ArgumentException ex) {
    				throw new ArgumentException(String.Format("Invalid pattern: {0}", wildcardPattern), ex);
    			}
    			return result;
    		}
    	}
