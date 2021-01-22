    public partial class RedBackgroundControl : UserControl
    {
        public RedBackgroundControl()
        {
            InitializeComponent();
            base.BackColor = Color.Red;
        }
    
        [DefaultValue(typeof(Color), "Red")]
        new public Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }
    }
