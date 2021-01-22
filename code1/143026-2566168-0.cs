    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string ContactHPhone { get;set; }
    public string ContactWPhone { get;set; }
    public Info(string name, string address, string city, string state, string zip, string contactHPhone, string contactWPhone)
    {
        Name = name;
        Address = address;
        City = city;
        State = state;
        Zip = zip;
        ContactHPhone = contactHPhone;
        ContactWPhone = contactWPhone;
        using (SqlConnection connect = new SqlConnection(connections))
        {
            string query = "Insert Into Personnel_Data (Name, StreetAddress, City, State, Zip, HomePhone, WorkPhone)" +
                "Values('" + Name + "','" + Address + "','" + City + "','" + State + "','" + Zip + "','" + ContactHPhone + "','" + ContactWPhone + "')";
            SqlCommand command = new SqlCommand(query, connect);
            connect.Open();
            command.ExecuteNonQuery();
        }
    }
