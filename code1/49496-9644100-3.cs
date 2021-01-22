    partial class ClientName
    {
        public void ValidateFirstName()
        {
            if (String.IsNullOrWhiteSpace(this.FirstName))
                throw new Exception("First Name is required.");
        }
        public void ValidateLastName()
        {
            if (String.IsNullOrWhiteSpace(this.LastName))
                throw new Exception("Last Name is required.");
        }
    }
