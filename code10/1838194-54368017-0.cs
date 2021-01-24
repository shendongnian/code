private void btnActivate_Click(object sender, EventArgs e)
{
    bool tempt = false;
    string enteredkey;
    SqlConnection con = new SqlConnection(@"connection string");
    con.Open();
    SqlCommand cmd = new SqlCommand("SELECT licenseType FROM LicenseKeys WHERE LicenseKeys = @LicenseKeys", con);
    cmd.Parameters.AddWithValue("@LicenseKeys", tbLicensekey.Text);
    enteredkey = ed.Encrypt(tbLicensekey.Text); // Not sure why you need the Encrpt method here
    var licenseType = cmd.ExecuteScalar<string>();
    if (licenseType != null)
    {
        tempt = true;
        MessageBox.Show("valid" + licenseType);
    }
    else 
    {
        MessageBox.Show("invalid");
    }
    con.Close();
}
