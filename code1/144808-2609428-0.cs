    public class FormControl : IFormControl
    {
        private readonly Control _control;
        public FormControl(Control control)
        {
            _control = control;
        }
        public bool Focus()
        {
            if(_control.Visible)
            {
                _control.Focus();
            }
            return _control.Visible;
        }
    }
