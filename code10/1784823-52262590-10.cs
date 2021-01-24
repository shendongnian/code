    public static class DB
    {
        private static string connectionString = "...";
        public static int thamer(int main_item_id)
        {
            using (var con = new MySqlConnection(connectString))
            using (var cmd = new MySqlCommand("thamer1", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@main_items_id_", MySqlDbType.Int32).Value = main_item_id;
                cmd.Parameters.Add("@res", MySqlDbType.Int32);
                cmd.Parmeters["@res"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@res"].Value;
            }
        }
    }
    private void a_KeyDown(object sender, KeyEventArgs e)
    {
        HITEM.Text = DB.thamer(int.Parse(a.Text)).ToString();
    }
