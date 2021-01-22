    public partial class MyNumericUpDown : NumericUpDown
    {
        public enum ValueChangedType
        {
            TextEdit,
            UpButton,
            DownButton,
            Programmatic
        }
        public ValueChangedType ChangedType = ValueChangedType.Programmatic;
        public MyNumericUpDown()
        {
            InitializeComponent();
        }
        public override void UpButton()
        {
            this.ChangedType = ValueChangedType.UpButton;
            base.UpButton();
        }
        public override void DownButton()
        {
            this.ChangedType = ValueChangedType.DownButton;
            base.DownButton();
        }
        protected override void OnLostFocus(EventArgs e)
        {
            this.ChangedType = ValueChangedType.TextEdit;
            base.OnLostFocus(e);
        }
        public void SetValue(decimal val)
        {
            this.ChangedType = ValueChangedType.Programmatic;
            this.Value = val;
        }
    }
