    [Flags]
    public enum Status
    {
        None = 0,
        One = 1,
        Two = 2,
        All = One | Two,
    }
    var flags = Enum.GetValues(typeof(Status))
                    .Cast<int>()
                    .Where(f=> f & o == f)
                    .ToList();
