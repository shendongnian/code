          using (SqlCommand cmd = new SqlCommand("Select * from Products where ID=@PID", con))
            {
                cmd.Parameters.Add("@PID", SqlDbType.Int);
                cmd.Parameters["@PID"].Value = PID;
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }
            }
