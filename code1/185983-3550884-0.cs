    private class Airplane
    {
        public string AirplaneName { get; set; }
        public int PassengerAmt { get; set; }
        public int FirstFlight { get; set; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        var planes = new List<Airplane>();
        planes.Add(new Airplane() { AirplaneName = "747 Jet", PassengerAmt = 417, FirstFlight = 1967 });
        myGridView.DataSource = planes;
        myGridView.DataBind();
    }
