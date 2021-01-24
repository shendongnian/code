    private List<DateTime> dates;
    private BindingList<DateTime> bDates;
    private BindingSource dSource;
    private DataTable dataTable = new DataTable();
    public Form1() {
      InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e) {
      dates = new List<DateTime>();
      dtpDate.Format = DateTimePickerFormat.Custom;
      dtpDate.CustomFormat = "dd/MM/yyyy";
      dtpTime.Format = DateTimePickerFormat.Custom;
      dtpTime.CustomFormat = "hh:mm";
      dtpTime.ShowUpDown = true;
      dataTable.Columns.Add("Date", typeof(DateTime));
    }
    private void button1_Click(object sender, EventArgs e) {
      DateTime input = dtpDate.Value.Date + dtpTime.Value.TimeOfDay;
      MessageBox.Show(input.ToString()); //This shows the date correctly
      dates.Add(input);
      bDates = new BindingList<DateTime>(dates);
      dSource = new BindingSource(bDates, null);
      grid.DataSource = dSource;
      grid.Columns[0].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
 
      // using datatable on second grid
      dataTable.Rows.Add(input);
      grid2.DataSource = dataTable;
      grid2.Columns[0].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss tt";
    }
