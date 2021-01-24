    [Export(typeof(EntitySelectorDialog))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class EntitySelectorDialog : Window
    {
        [ImportingConstructor]
        public EntitySelectorDialog(EntitySelectorViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
            Content = new ContentControl() { Content = vm };
        }
    }
