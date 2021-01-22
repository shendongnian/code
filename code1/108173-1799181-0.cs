    using(SqlConnection connexion = new Sqlconnection(youconenctionstring))
    using(SqlCommand command = conenxion.Createcommand())
    {
        command.Commandtext = "yourProcName";
        command.CommandType = CommandType.StoredProcedure;
        command.Paramters.Add("@yourparam",yourparamvalue);
        connexion.Open();
        SqlDataReader reader = command.ExecuteReader();
    
    
        List<User> users = new List<User>;
        List<Adress> adresses = new List<User>;
        while(read.Read())
        {
            User user = new User();
            user.firstName = (string) read["FirstName"];
            users.Add(user);
         }
        read.NextResult();
        while(read.Read)
        {
            Address address = new Address();
            address.City = (string) read["Name"];
            adresses.Add(address);
        }
       //make what you want with your both list
    }
