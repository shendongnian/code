    public class DependentFormControl : IFormControl
    {
        private readonly Control _control;
        private readonly Func<bool> _prerequisite;
        public DependentFormControl(Control control, Func<bool> prerequisite)
        {
            _control = control;
            _prerequisite = prerequisite;
        }
        public bool Focus()
        {
            var focused = _prerequisite() && _control.Visible;
            if(focused)
            {
                _control.Focus();
            }
            return focused;
        }
    }
