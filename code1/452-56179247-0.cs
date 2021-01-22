    public static MySqlConnection obtenerconexion()
            {
                string server = "Server";
                string database = "Name_Database";
                string Uid = "User";
                string pwd = "Password";
                MySqlConnection conect = new MySqlConnection("server = " + server + ";" + "database =" + database + ";" + "Uid =" + Uid + ";" + "pwd=" + pwd + ";");
    
                try
                {
                    conect.Open();
                    return conect;
                }
                catch (Exception)
                {
                    MessageBox.Show("Error. Ask the administrator", "An error has occurred while trying to connect to the system", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return conect;
                }
            }
