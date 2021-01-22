    public static void Main(string[] args)
    {
        using (Context context = new Context())
        {
            var arguments = context.Arguments.WhereIn(arg => arg.Arg, args); //args contains arg.Arg
        }
    }
