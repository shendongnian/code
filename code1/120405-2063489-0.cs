    class Passenger
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
    }
    
    private void AddButton_Click(object sender, EventArgs e)
    {
        var passenger = new Passenger
                            {
                                FirstName = txtFname.Text,
                                LastName = txtLname.Text,
                                Address = txtAdd.Text,
                                Age = int.Parse(txtAge.Text)
                            }
        AddPassenger(passenger);
    }
