    public class TestClass
    {
        public string this[string field]
        {
            get => this.GetFieldValue<string>(field);
            set => this.TrySetFieldValue(field, value);
        }
    }
