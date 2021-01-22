    public partial class CustomCombo : ComboBox
    {
        public CustomCombo ()
        {
            InitializeComponent();
        }
        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            base.OnMeasureItem(e);
        }
        public void RaiseOnMeasureItem()
        {
            this.RefreshItems();
        }
    }
