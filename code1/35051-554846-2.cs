    public interface IControlProvider<T>
        where T : Control, ISpecialControl
    {
        T CreateControl();
    }
    
    public class SpecialTextBoxProvider : IControlProvider<SpecialTextBox>
    {
        public SpecialTextBox CreateControl()
        {
            return new SpecialTextBox();
        }
    }
