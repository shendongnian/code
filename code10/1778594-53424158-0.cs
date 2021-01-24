    public class Person
    {
        public int Number { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Name => $"{FirstName} {MiddleName} {LastName}"; 
    }
    // Load data
    var persons = new List<Person>();
    using (var connection = new SqlConnection(connectionsString))
    using (var command = connection.CreateCommand())
    {
        command.CommandText = "SELECT PersNbr, PersFirstName, PersMiddleName, PersLastName FROM Pers";
        connection.Open();
        
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                var person = new Person
                {
                    Number = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    MiddleName = reader.GetString(2),
                    LastName = reader.GetString(3),
                };
                persons.Add(person);
            }
        }
    }
    combobox.DisplayMember = "Name";
    combobox.DataSource = persons;
    
