    public class MyDataGridView : DataGridView
    {
        private bool mbAutoGenerateColumns = false;
        [Browsable(true)]
        [Category("Behavior")]
        [DefaultValue(false)]
        new public bool AutoGenerateColumns
        {
            get { return base.AutoGenerateColumns; }
            set { base.AutoGenerateColumns = mbAutoGenerateColumns = value; }
        }
        public MyDataGridView()
        {
            // Set AGC to false right on the start
            AutoGenerateColumns = false;
        }
        protected override void OnAutoGenerateColumnsChanged(EventArgs e)
        {
            base.OnAutoGenerateColumnsChanged(e);
            // When AGC gets changed, check if the change happened
            //  internally or through the new property.
            // If internally, revert!
            // Since DGV has a tendency to enable AGC, only the setting
            //  to false is explicitly needed, the rest happens automatically
            if(!mbAutoGenerateColumns && base.AutoGenerateColumns)
                base.AutoGenerateColumns = false;
        }
    }
