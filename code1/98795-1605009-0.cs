    [ImmutableObject(true)] // I'm sure this used to toggle intellisense for attribs
    public class FooAttribute : BarAttribute
    {
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        [ReadOnly(true)]
        public new string Name { get { return base.Name; } }
    }
