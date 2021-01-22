    public static void Main(string[] args)
    {
        using (Context context = new Context())
        {
            //args contains arg.Arg
            var arguments = context.Arguments.WhereIn(arg => arg.Arg, args);   
        }
    }
