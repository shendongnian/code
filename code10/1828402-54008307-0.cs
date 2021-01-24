    public static class SomeRegexConsts
    {
        static SomeRegexConsts(){
		    FullName = $"{Name} {Surname}";
	    }
	    public static readonly string FullName;
        private static readonly string Name = "[A-Z][a-z]+";
        private static readonly string Surname = "[A-Z][a-z]+";
