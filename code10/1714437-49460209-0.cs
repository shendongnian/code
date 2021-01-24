    public partial class ABMControl<T> : UserControl
    {
        public ABMControl()
        {
            InitializeComponent();
            this.bindingSource.DataSource = typeof(T)
        }
    }
