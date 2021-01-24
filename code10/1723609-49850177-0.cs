    public class MvxUITextFieldEditingDidBeginTargetBinding : MvxTargetBinding
    {
        private IDisposable _subscription;
        private ICommand _command;
    
        protected UITextField TextField => Target as UITextField;
    
        public override Type TargetType => typeof(ICommand);
        public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;
    
        public MvxUITextFieldEditingDidBeginTargetBinding(object target)
            : base(target)
        {
        }
    
        public override void SetValue(object value)
        {
            _command = value as ICommand;
        }
    
        public override void SubscribeToEvents()
        {
            var textField = TextField;
            if (TextField == null) return;
    
            _subscription = textField.WeakSubscribe(nameof(textField.EditingDidBegin), HandleEditingBegin);
        }
    
        private void HandleEditingBegin(object sender, EventArgs e)
        {
            if (_command == null) return;
            if (!_command.CanExecute(null)) return;
    
            _command.Execute(null);
        }
    
        protected override void Dispose(bool isDisposing)
        {
            base.Dispose(isDisposing);
            if (!isDisposing) return;
    
            _subscription?.Dispose();
            _subscription = null;
        }
    }
