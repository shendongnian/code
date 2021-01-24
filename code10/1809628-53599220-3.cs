    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            
            ParameterList = new CustomParameterList();
        }
        [Category("Custom")]
        [Description("A list of custom parameters.")]
        public CustomParameterList ParameterList { get; }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ParameterList.Add("First", "The first parameter");
        }
    }
