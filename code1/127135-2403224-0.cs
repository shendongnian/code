    public partial class TestForm : Form
    {
        public DataClassesDataContext DataContext;
        
        // Incorrect: public IQueryable<T> datasource;
        // Correct:
        public BindingSource TsDataSource;
        
        // Ctor
        public TestForm()
        {
        InitializeComponent();
    
        // L2S data context
        this.DataContext = new DataClassesDataContext();
    
        // Get the variable for the data source
        // Incorrect: this.datasource = this.DataContext.Ts;
        // Correct:
        this.TsDataSource = new BindingSource();
        this.TsDataSource.DataSource = this.DataContext.Ts;
    
        // setup the binding for the combobox
        this.comboBox1.DataSource = this.TsDataSource;
        this.comboBox1.DisplayMember = "Description";
        this.comboBox1.ValueMember = "Id";
        // assign the databindings of the text boxes to the selectedItem of the combo box    
        TId.DataBindings.Add(new Binding("Text", this.TsDataSource, "Id"));
        TUser.DataBindings.Add(new Binding("Text", this.TsDataSource, "User"));
        TDescription.DataBindings.Add(new Binding("Text", this.TsDataSource, "Description"));
    }
