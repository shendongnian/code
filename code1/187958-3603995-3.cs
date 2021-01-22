    public partial class Form1 : Form
    {
        private BindingSource bs;
        private BindingList<Holder> bList;
        public Form1()
        {
            InitializeComponent();
            bList = new BindingList<Holder>();
            bList.Add(new Holder("test1"));
            bList.Add(new Holder("test2"));
            
            bs = new BindingSource();
            bs.DataSource = bList;
            cmb.DataSource = bs;
            cmb.DisplayMember = "Name";
            cmb.ValueMember = "Name";
            // updates when focus leaves the textbox
            txt.DataBindings.Add("Text", bs, "Name");
            // updates when the property changes
            //txt.DataBindings.Add("Text", bs, "Name", false, DataSourceUpdateMode.OnPropertyChanged);
        }
    }
