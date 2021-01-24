    public class MPOOData implements Serializable
        {
            private static final long serialVersionUID = -6572712057013837374L;
               
            public int ID { get; set; }
            public string Name { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Manager { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public string Area { get; set; }
            public string District { get; set; }
            public int AreaID { get; set; }
            public int DistrictID { get; set; }
            public DateTime StartDate { get; set; }
            public string Zips { get; set; }
        }
