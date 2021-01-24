    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            
            ParameterList = new List<Parameter>();
        }
        [Category("Custom")]
        [Description("A list of custom parameters.")]
        public List<Parameter> ParameterList { get; }
    }
