    MyClassRepository myClassRepository;
    BindingSource gridBindingSource;
    public Form1() {
      InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e) {
      try {
        myClassRepository = new MyClassRepository();
        gridBindingSource = new BindingSource(myClassRepository.MyClassList, "");
        dataGridView1.DataSource = gridBindingSource;
      }
      catch (Exception ex) {
        MessageBox.Show("Error: " + ex.Message); 
      }
    }
    private void button1_Click_1(object sender, EventArgs e) {
      MessageBox.Show("Binding source count:" + gridBindingSource.Count + Environment.NewLine +
                      "MyClassList count: " + myClassRepository.MyClassList.Count);
    }
