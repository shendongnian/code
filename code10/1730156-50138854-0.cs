    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lbxCars.SelectedValue != null)
        {
            var tempCar = cars.Any(e=>e.ID==lbxCars.SelectedValue );
        }
    }
