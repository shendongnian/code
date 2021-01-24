    public interface Example
    {
        string Value { get; set; }
    }
    public class Something
    {
        public List<Example> keybind... // instantiate
        public Something()
        {
            keybind.ForEach(b =>
            {
                b.Value = // new value
            }
        }
    }
