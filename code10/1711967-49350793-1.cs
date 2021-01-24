    public class CustomButton : Button
    {
        private NormalColor CurrentColorSelection = 0;
        public NormalColor CLR
        {
            get { return CurrentColorSelection; }
            set { SetBackColor(value); }
        }
        public enum NormalColor
        {
            Red,
            Blue,
            Yellow
        }
        public CustomButton()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            SetBackColor(CurrentColorSelection);
            this.ForeColor = Color.White;
            this.FlatAppearance.BorderSize = 0;
            this.FlatStyle = FlatStyle.Flat;
            this.Size = new Size(100, 100);
            this.MouseEnter += this.CustomButton_MouseEnter;
            this.MouseLeave += this.CustomButton_MouseLeave;
            this.MouseClick += this.CustomButton_MouseClick;
        }
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }
        private void SetBackColor(NormalColor value)
        {
            this.CurrentColorSelection = value;
            this.BackColor = Color.FromName(value.ToString());
        }
        
       //(...)
       //Event Handlers
    }
