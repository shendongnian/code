    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class CustomParameterList : System.Collections.ObjectModel.Collection<Parameter>
    {
        public override string ToString() => $"List With {Count} Items.";
        public void Add(string name, string caption) => Add(new Parameter() { Name = name, Caption = caption });
    }
