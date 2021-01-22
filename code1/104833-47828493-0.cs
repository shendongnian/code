    public partial class TooltipButton : UserControl
    {
        public TooltipButton()
        {
            InitializeComponent();
        }
        public new bool Enabled
        {
            get { return button.Enabled; }
            set { button.Enabled = value; }
        }
        [Category("Appearance")]
        [Description("The text displayed by the button.")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public override string Text
        {
            get { return button.Text; }
            set { button.Text = value; }
        }
        [Category("Action")]
        [Description("Occurs when the button is clicked.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new event EventHandler Click;
        private void button_Click(object sender, EventArgs e)
        {
            // Bubble event up to parent
            Click?.Invoke(this, e);
        }
    }
