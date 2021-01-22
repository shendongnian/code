    public partial class TestForm : Form
    {
        public DataClassesDataContext DataContext;
    
        public IQueryable<T> datasource;
        private BindingManagerBase bmComboBoxSelectedItem;
    
        // Ctor
        public TestForm()
        {
            InitializeComponent();
    
            // L2S data context
            this.DataContext = new DataClassesDataContext();
    
            // Get the variable for the data source
            this.datasource = this.DataContext.Ts;
    
            // setup the binding for the combobox
            this.comboBox1.DataSource = this.datasource;
            this.comboBox1.DisplayMember = "Description";
            this.comboBox1.ValueMember = "Id";
    
            // assign the databindings of the text boxes to the selectedItem of the combo box    
            // this is where the problem is, afaik
            TId.DataBindings.Add(new Binding("Text", this.comboBox1, "SelectedItem.Id"));
            TUser.DataBindings.Add(new Binding("Text", this.comboBox1, "SelectedItem.User"));
            TDescription.DataBindings.Add(new Binding("Text", this.comboBox1, "SelectedItem.Description"));
            bmComboBoxSelectedItem = this.BindingContext[this.comboBox1, "SelectedItem"];
        }
        // make sure you assign this event on the forms designer or your preferred method
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bmCustomers.ResumeBinding();
        }
    }
