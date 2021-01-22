    public partial class CustomListView : ListView
    {
        public CustomListView()
        {
            InitializeComponent();
        }
        public System.Windows.Forms.ListView.ListViewItemCollection CustomExposedItems
        {
            get
            {
                return base.Items;
            }
        }
        [EditorBrowsable(EditorBrowsableState.Never)]    
        [Browsable(false)]    
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("Use the new custom way of adding items xyz")]
        public new System.Windows.Forms.ListView.ListViewItemCollection Items    
        { 
            get { throw new NotSupportedException(); }    
        }
    }
