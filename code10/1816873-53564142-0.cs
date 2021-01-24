    public partial class BaseForm : Form, BaseInterface
    {
        public object genericItem;
        
        // this can be overridden in extending classes
        virtual int SomeDataHere => throw new NotImplementedException();
    
        public BaseForm()
        {
            InitializeComponent();
        }
    
        public void Add()
        {
            var a = genericItem.ToXml();
    
            MessageBox.Show(a);
        }
    
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    
        public void Update(string xml)
        {
            throw new NotImplementedException();
        }
    
        public void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(SomeDataHere);
            Add();
        }
    }
