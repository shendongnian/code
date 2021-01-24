    /// <summary>
    /// Equivalent to KeyValuePair<object, string> but with more memorable property names for use with ComboBox controls
    /// </summary>
    /// <remarks>
    /// Bind ItemsSource to IEnumerable<ValueDisplayPair>, set DisplayMemberPath = Display, SelectedValuePath = Value, bind to SelectedValue
    /// </remarks>
    public abstract class myValueDisplayPair
    {
        public object Value { get; protected set; }
        public string Display { get; protected set; }
    }
    /// <summary>
    /// Equivalent to KeyValuePair<T, string>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class myValueDisplayPair<T> : myValueDisplayPair
    {
        internal perValueDisplayPair(T value, string display)
        {
            Value = value;
            Display = display;
        }
        public new T Value { get; }
        public override string ToString() => $"Display: {Display} Value: {Value}";
    }
