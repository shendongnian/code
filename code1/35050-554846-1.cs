    public class ControlProvider : IControlProvider<T>
        where T : Control, ISpecialControl, new()
    {
        public T CreateControl()
        {
            return new T();
        }
    }
    var control = ControlProvider<SpecialTextBox>.CreateControl();
