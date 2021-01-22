    private class Airplane
    {
        public string AirplaneName { get; set; }
        public int PassengerAmt { get; set; }
        public int FirstFlight { get; set; }
    }
    public Form1()
    {
        InitializeComponent();
        var planes = new List<Airplane>();
        planes.Add(new Airplane() { AirplaneName = "747 Jet", PassengerAmt = 417, FirstFlight = 1967 });
        dataGridView1.DataSource = planes;
        
    }
