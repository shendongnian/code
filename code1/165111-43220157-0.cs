    public class ComboBoxItem<T>
    {
        public string Name;
        public T value = default(T);
        public ComboBoxItem(string Name, T value)
        {
            this.Name = Name;
            this.value = value;
        }
        public override string ToString()
        {
            return Name;
        }
    }
