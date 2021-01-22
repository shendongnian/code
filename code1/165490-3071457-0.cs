    public bool IsFalse { get; set; }
    public bool IsTrue
    {
        get { return !IsFalse; }
        set { IsFalse = !value; }
    }
    public void Something()
    {
        var isTrue = this.IsTrue;
        var isFalse = this.IsFalse;
    }
