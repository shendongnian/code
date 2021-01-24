    public class TextSwitchRightTextTargetBinding : MvxAndroidTargetBinding
    {
        public TextSwitchRightTextTargetBinding(SwitchRightText switchRightText)
            : base(switchRightText)
        {
        }
        private SwitchRightText SwitchRightText => (SwitchRightText)this.Target;
        protected override void SetValueImpl(object target, object value)
        {
            this.SwitchRightText.TextView.Text = (string)value;
        }
        public override Type TargetType => typeof(string);
        public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;
        public override void SubscribeToEvents()
        {
            base.SubscribeToEvents();
            this.SwitchRightText.TextView.TextChanged += TextView_TextChanged;
        }
        private void TextView_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            this.FireValueChanged(this.SwitchRightText.TextView.Text);
        }
        protected override void Dispose(bool isDisposing)
        {
            base.Dispose(isDisposing);
            if(isDisposing)
                this.SwitchRightText.TextView.TextChanged -= TextView_TextChanged;
        }
    }
