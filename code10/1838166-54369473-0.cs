    public Form1()
    {
        InitializeComponent();
        DateTime today = DateTime.Now;
        var shortDate = today.Date.AddDays(0);
        var ReservedCars = (from r in db.Reservation 
            select new ReservationRow(
                r.ReservationId,
                r.StartDate,
                r.EndDate)).ToList();
        dgvReservedCars.DataSource = ReservedCars;
    }
    private void dgvReservedCars_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        DateTime today = DateTime.Now;
        var shortDate = today.Date.AddDays(0);
        foreach (DataGridViewRow row in dgvReservedCars.Rows)
        {
            ReservationRow res = row.DataBoundItem as ReservationRow;
            if (res.EndDate <= shortDate)
            {
                row.DefaultCellStyle.BackColor = Color.Red;
            }
        }
    }
