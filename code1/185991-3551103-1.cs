    public SunData SunData { get; set; }
    public override OuterSpaceData Data
    {
      get { return SunData; }
      set { SunData = (SunData)value; }
    }
