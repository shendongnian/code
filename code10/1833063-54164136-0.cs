    //This is where the textboxes are populated 
    protected void Page_Load(object sender, EventArgs e)
    {
       if (!IsPostBack)
       {
        string employeID = gestiondeempleados.empleadoID;
        string queryStr = "SELECT empleado_id,nombreusuario,nombre  Where empleado_id =" + employeID;
        using (conn = new MySql.Data.MySqlClient.MySqlConnection(connString))
        {
            using (cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn))
            {
                conn.Open();
                using (reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                         firstname.Text = reader.GetString(reader.GetOrdinal("nombre"));
                    }
                }
            }
        }
    }
