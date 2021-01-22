    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }                
    
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
    
            // this will be the datasource for the combo box column; you could also bind it to a dataset
            List<Foo> foos = new List<Foo>() {
                new Foo() { FooID = 0, FooName = "No Foo." }, 
                new Foo() { FooID = 1, FooName = "Foo Me Once" },
                new Foo() { FooID = 2, FooName = "Foo Me Twice" },
                new Foo() { FooID = 3, FooName = "Pity The Foo!" }
            };
    
            DataGridView dataGridView1 = new DataGridView();
            dataGridView1.AutoGenerateColumns = false;
    
            // add normal text column
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "MyText";
            column.Name = "Text";
            dataGridView1.Columns.Add(column);
    
            // add the combo box column 
            DataGridViewComboBoxColumn comboCol = new DataGridViewComboBoxColumn();
            comboCol.Name = "Foo";
            // bind it to the list of foos to populate it
            comboCol.DataSource = foos;
            // specify which property of the grid's datasource to bind 
            comboCol.DataPropertyName = "MyFoo";
            // specify the property of the combo's datasource to bind 
            comboCol.ValueMember = "FooID";
            // specify the property of the combo's datasource to display
            comboCol.DisplayMember = "FooName";
            
            dataGridView1.Columns.Add(comboCol);
    
            // add some data
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.Add(new BusinessObject(1, "You say"));
            bindingSource1.Add(new BusinessObject(2, "George says"));
            bindingSource1.Add(new BusinessObject(3, "Mr. T says"));
            bindingSource1.Add(new BusinessObject());
            dataGridView1.DataSource = bindingSource1;
    
            Controls.Add(dataGridView1);
            dataGridView1.Dock = DockStyle.Fill;
        }        
    
        class Foo
        {
            public int FooID { get; set; }
            public string FooName { get; set; }        
        }
        class BusinessObject
        {
            public BusinessObject(int foo, string text)
            {
                MyFoo = foo;
                MyText = text;
            }
            public BusinessObject()
            {
                MyFoo = 0;
                MyText = "";
            }            
            public string MyText { get; set; }
            public int MyFoo { get; set; }
        }
    }
