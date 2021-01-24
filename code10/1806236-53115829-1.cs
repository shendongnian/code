    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string PersonInCharge { get; set; }
        public string PhoneNumber { get; set; }
        public static List<Tuple<string, Manufacturer>> GetAllManufacturers()
        {
            //This one i will make example with interaction to database
            List<Tuple<string, Manufacturer>> list = new List<Tuple<string, Manufacturer>>();
            using(SqlConnection con = new SqlConnection("SomeSqlString"))
            {
                con.Open();
                using(SqlCommand cmd = new SqlCommand("Select Id, Name, City, Person, Phone from Manufacturers", con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    
                    while(dr.Read()) //Will read one by one line
                    {
                        Manufacturer m = new Manufacturer();
                        m.Id = Convert.ToInt32(dr[0]);
                        m.Name = dr[1].ToString();
                        m.City = dr[2].ToString();
                        m.PersonInCharge = dr[3].ToString();
                        m.PhoneNumber = dr[4].ToString();
                        list.Add(new Tuple<string, Manufacturer>(m.Id, m));
                    }
                }
            }
            return list;
        }
    }
