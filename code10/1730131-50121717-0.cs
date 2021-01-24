    public class WebMailer
    { 
        public void process()
        {
            List<Addr> Addrs = new List<Addr>();
            SqlCommand command = new SqlCommand();
            using (var reader = command.ExecuteReader())
            {
                using (SqlDataReader r = command.ExecuteReader())
                {
                    Addrs.Add(new Addr(r.GetString(0), r.GetString(1)));
                }
            }
            foreach(Addr addr in Addrs)  // can use parallel here
            { }
        }
    }
    s
