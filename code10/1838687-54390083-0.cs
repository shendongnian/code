csharp
        public bool good(string emailadress)
        {
            SqlCommand cmd = new SqlCommand("SELECT Email FROM Clients", con);
            SqlDataReader dr = cmd.ExecuteReader();//error is here
            while (dr.Read())
            {
                if (dr[0].ToString() == textBox6.Text)
                {
                    dr.Close();
                    return false;
                }
            }
            dr.Close();
            return true;
        }
