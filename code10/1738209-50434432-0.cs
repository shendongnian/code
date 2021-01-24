    string connectionStr = ConfigurationManager.ConnectionStrings["mysqlbaglanti"].ToString());
    void GirisYap()
    {
        using (var cn = new new MySqlConnection(connectionStr))
        {
            // command object should take connection object
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM kullanicilar WHERE kullaniciadi='" + txtKullaniciAdi.Text + "' AND sifre='" + txtSifre.Text + "'", cn))
            {
                ........
            }
    }
