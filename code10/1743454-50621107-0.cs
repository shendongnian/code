    internal decimal? OneFieldIntenal { get; set; }
    public int? OneField
    {
        get => OneFieldIntenal.HasValue ? (int)OneFieldIntenal.Value : null;
        set => OneFieldIntenal = value;
    }
