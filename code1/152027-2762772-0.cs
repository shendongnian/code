    public Params Parse(string input)
    {
        var @params = new Params();
        var argv = ConvertToArgv(input);
        new NDesk.Options.OptionSet
            {
                {"abc=", v => Double.TryParse(v, out @params.abc)},
                {"sdc=", v => Double.TryParse(v, out @params.sdc)},
                {"www=", v => Double.TryParse(v, out @params.www)}
            }
            .Parse(argv);
        return @params;
    }
    private string[] ConvertToArgv(string input)
    {
        return input
            .Replace('(', '-')
            .Split(new[] {')', ' '});
    }
