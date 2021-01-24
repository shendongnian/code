    private void updatebtn_Click(object sender, EventArgs e)
    {
        vehimodel.Vehicle_No = vehiclenotextbox.Text.Trim();
        vehimodel.Name = nametextbox.Text.Trim();
        vehimodel.Mobile = mobiletextbox.Text.Trim();
        vehimodel.Email_ID = emailtextbox.Text.Trim();
        vehimodel.Make_Model = makeandmodeltextbox.Text.Trim();
        using(ShivaniVehicleDbContext db = new ShivaniVehicleDbContext())
        {
            db.Entry(vehimodel).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            MessageBox.Show("Sucessfully Created");
        }
    }
