    public class MyControl : Control
    {
        public MyControl()
        {
            InitializeComponent();
            textBox1.TextChanged += BubbleModified;
            // etc.
        }
        protected void BubbleModified(object sender, EventArgs e)
        {
            OnModified(e);
        }
        protected void OnModified(EventArgs e)
        {
            var handler = Modified;
            if (handler != null)
                handler(this, e);
        }
        [Category("Behavior")]
        [Description("Occurs when data on the control is modified.")]
        public event EventHandler Modified;
    }
