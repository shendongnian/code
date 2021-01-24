    private BindingList<Parking> parking = null;
    public Form1()
    {
        InitializeComponent();
        var tmpList = new List<Parking>
        {
            new Parking(1, "TKN1893", DateTime.Now),
            new Parking(2, "TKN1951", DateTime.Now),
            new Parking(3, "TNA725", DateTime.Now),
        };
        this.parking = new BindingList<Parking>();
        tmpList.ForEach(elm => parking.Add(elm));
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        //(...)
        this.dataGridView1.DataSource = this.parking;            
    }              
    private void btnAddRecord_Click(object sender, EventArgs e)
    {
        this.parking.Add(new Parking(10, "IP3147", DateTime.Now));
    }
    private void btnRemoveRecord(string value)
    {
        this.parking.RemoveAt(0);
    }
