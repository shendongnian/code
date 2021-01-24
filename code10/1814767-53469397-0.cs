    public interface IFieldExposer<T>
    {
        IEnumerable<Func<T,string>> SelectedFields { get; }
    }
    public static class FieldExposerExtensions
    {
        public static IEnumerable<Func<T,string>> MatchIgnoreCase<T>( this IEnumerable<Func<T,string>> stringProperties, T source, string matchText)
        {
            return stringProperties.Where(stringProperty => String.Equals( stringProperty( source), matchText, StringComparison.OrdinalIgnoreCase));
        }
    }
    class DataClass : IFieldExposer<DataClass>
    {
        public string PropertyOne { get; set; }
        public string PropertyTwo { get; set; }
        public ChildClass Child { get; set; }
        public IEnumerable<Func<DataClass, string>> SelectedFields {
            get {
                return new Func<DataClass, string>[] { @this => @this.PropertyOne, @this => @this.Child.PropertyThree };
            }
        }
        public override string ToString() => this.PropertyOne + " " + this.PropertyTwo + " " + this.Child.PropertyThree;
    }
    class ChildClass
    {
        public string PropertyThree { get; set; }
    }
