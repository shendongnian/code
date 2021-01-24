    public enum Errs
    {
        Default = 0,
        Primary = 1,
        Success = 2,
        Info = 3,
        Warning = 4,
        Danger = 5,
    }
    var messageKind = Errs.Danger.ToString().ToLower();
