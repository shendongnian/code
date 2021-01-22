    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            this.InternalAnger = new Anger();
            this.InternalAnger.SomeValue = 2;
            this.Angers.Add(this.InternalAnger);
        }
    
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<Anger> Angers
        {
            get { return this.list; }
        }
    
        public Anger InternalAnger { get; set; }
    
        private List<Anger> list = new List<Anger>();
        private Anger _InternalAnger;
    }
    
    public class Anger
    {
        public Anger() { }
    
        public int SomeValue { get; set; }
    }
