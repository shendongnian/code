    public sealed partial class ViewMode : UserControl
    {
        public static ViewMode Current { get; private set; }
        
        public ViewMode()
        {
            this.InitializeComponent();
            Current = this;
        }
    }
