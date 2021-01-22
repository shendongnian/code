    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public void CheckInvariants()
        {
            assertNotNull(FirstName, "first name");
            assertNotNull(LastName, "last name");
        }
        
        // here are your checks ...
        private void assertNotNull(string input, string hint)
        {
            if (input == null)
            {
                string message = string.Format("The given {0} is null.", hint);
                throw new ApplicationException(message);
            }
        }
