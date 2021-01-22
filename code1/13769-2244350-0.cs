    public class ButtonNoFocus : Button
    {
        public ButtonNoFocus()
            : base()
        {
            base.SetStyle(ControlStyles.Selectable, false);
        }
    }
