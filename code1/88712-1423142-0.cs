    public partial class TestInterface_ADicionaryVertice : Form 
    {
        private List<VerticeDNPM> listVertices = new List<VerticeDNPM>();
        public List<VerticeDNPM> { get { return listVertices; } }
    
        public TestInterface_ADiciontaryVertice()
        {
            InitializeComponent();
            ...manipulate list of points here...   
        }
    }
