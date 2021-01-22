    new Thread(delegate() {
        getTenantReciept_UnitTableAdapter1.Fill(
            rentalEaseDataSet1.GetTenantReciept_Unit);
    }).Start();
    new Thread(delegate() {
        getTenantReciept_TenantNameTableAdapter1.Fill(
            rentalEaseDataSet1.GetTenantReciept_TenantName);
    }).Start();
