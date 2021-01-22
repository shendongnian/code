    public static class EnumExtension
    {
	    public static String ToDisplayString(this Enum e)
	    {
            Regex regex = new Regex(@"([^\^])([A-Z][a-z$])");
            return regex.Replace(e.ToString(), new MatchEvaluator(m =>
            {
                return String.Format("{0} {1}", m.Groups[1].Value, m.Groups[2].Value);
            }));
	    }
    }
