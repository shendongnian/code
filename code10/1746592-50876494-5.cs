        public static class LikeExpression
        {
            private static readonly MethodInfo ApplyLikeMethodInfo = typeof(LikeExpression).GetMethod("ApplyLike");
            private static readonly MethodInfo ApplyLikeNoCaseMethodInfo = typeof(LikeExpression).GetMethod("ApplyLikeNoCase");
            private static readonly MethodInfo ApplyNotLikeMethodInfo = typeof(LikeExpression).GetMethod("ApplyNotLike");
            private static readonly MethodInfo ApplyNotLikeNoCaseMethodInfo = typeof(LikeExpression).GetMethod("ApplyNotLikeNoCase");
    
            public static Expression Like(Expression lhs, Expression pattern, bool caseSensitive = false)
            {
                return caseSensitive
                    ? Expression.Call(ApplyLikeMethodInfo, lhs, pattern)
                    : Expression.Call(ApplyLikeNoCaseMethodInfo, lhs, pattern);
            }
    
            public static Expression NotLike(Expression lhs, Expression pattern, bool caseSensitive = false)
            {
                return caseSensitive
                    ? Expression.Call(ApplyNotLikeMethodInfo, lhs, pattern)
                    : Expression.Call(ApplyNotLikeNoCaseMethodInfo, lhs, pattern);
            }
    
            public static bool ApplyLike(string text, string likePattern)
            {
                string pattern = PatternToRegex(likePattern);
                return Regex.IsMatch(text, pattern, RegexOptions.None);
            }
    
            public static bool ApplyLikeNoCase(string text, string likePattern)
            {
                string pattern = PatternToRegex(likePattern);
                return Regex.IsMatch(text, pattern, RegexOptions.IgnoreCase);
            }
    
            public static bool ApplyNotLike(string text, string likePattern)
            {
                string pattern = PatternToRegex(likePattern);
                return !Regex.IsMatch(text, pattern, RegexOptions.None);
            }
    
            public static bool ApplyNotLikeNoCase(string text, string likePattern)
            {
                string pattern = PatternToRegex(likePattern);
                return !Regex.IsMatch(text, pattern, RegexOptions.IgnoreCase);
            }
    
            public static string PatternToRegex(string pattern)
            {
                pattern = Regex.Escape(pattern);
                pattern = pattern.Replace("%", @".*");
                pattern = $"^{pattern}$";
    
                return pattern;
            }
        }
