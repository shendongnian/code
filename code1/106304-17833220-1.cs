    public partial class ToolStripTextBoxOwnerDraw : ToolStripControlHost
    {
        private TextBoxOwnerDraw InnerTextBox
        {
            get { return Control as TextBoxOwnerDraw; }
        }
        public ToolStripTextBoxOwnerDraw() : base(new TextBoxOwnerDraw()) { }
        public TextBox ToolStripTextBox
        {
            get { return InnerTextBox.TextBox; }
        }
        public int CornerRadius
        {
            get { return InnerTextBox.CornerRadius; }
            set
            {
                InnerTextBox.CornerRadius = value;
                InnerTextBox.Invalidate();
            }
        }
        public Color BorderColor
        {
            get { return InnerTextBox.BorderColor; }
            set
            {
                InnerTextBox.BorderColor = value;
                InnerTextBox.Invalidate();
            }
        }
        public int BorderSize
        {
            get { return InnerTextBox.BorderSize; }
            set
            {
                InnerTextBox.BorderSize = value;
                InnerTextBox.Invalidate();
            }
        }
        public override Size GetPreferredSize(Size constrainingSize)
        {
            return InnerTextBox.PrefSize;
        }
    }
