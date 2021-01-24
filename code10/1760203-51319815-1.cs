    public void SqlConn()
    {
        string tanim = null;
        using (SqlConnection connect = new SqlConnection("connectionString"))
        {
            using (SqlCommand cmdTanim = new SqlCommand())
            {
                cmdTanim.Connection = connect;
                cmdTanim.CommandText = "select Tanım from TümEnvanter$ where Ekipman = @param";
                cmdTanim.Parameters.AddWithValue("@param", comboBox_ekipman.Text);
                connect.Open();
                tanim = (string)cmdTanim.ExecuteScalar();
            }
        }
        labelTanim.Text = "Ekipman Tanımı: " + tanim + " ";
    }
