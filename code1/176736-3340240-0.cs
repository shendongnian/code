    private static Padding DefaultLabelPadding = new Padding(2);
    private internalLabelPadding = DefaultLabelPadding;
    public Padding LabelPadding { get { return internalLabelPadding; } set { internalLabelPadding = value; LayoutNow(); } }
    // next comes the magic
    bool HasLabelPadding() { return LabelPadding != DefaultLabelPadding; }
