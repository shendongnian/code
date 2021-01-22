    internal IFirstInterface First { get; private set; }
    
    IFirstInterface ISecondInterface.First
    {
        get { return this.First; }
    }
