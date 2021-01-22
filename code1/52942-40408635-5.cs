    string firstName = txtFirstName.Text;
    string lastName = txtLastName.Text;
    List<string> props = new List<string>();
    props.Add("OFFICE");
    props.Add("DEPARTMENT");
    props.Add("LOCATION");
    props.Add("USERNAME");
    DataTable dt = GetUsersFromName(firstName, lastName, props);
