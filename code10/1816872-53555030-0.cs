    public abstract partial class BaseForm : Form, BaseInterface
    {
        public object genericItem;
    
        public BaseForm()
        {
            InitializeComponent();
        }
    
        public void Add()
        {
            var a = genericItem.ToXml();
            MessageBox.Show(a);
        }
         
        public abstract object GatherData();
    
        public void button1_Click(object sender, EventArgs e)
        {
            genericItem = GatherData();
            Add();
        }
    }
    
    public partial class Definitions : BaseForm
    {
        public Definitions() : base()
        {
            InitializeComponent();
        }
    
        public override object GatherData()
        {
            return new SomeKindOfData();
        }
    }
