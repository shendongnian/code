    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    public class MyTextBox : TextBox
    {
        public MyTextBox()
        {
            this.Person = new Person
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 45
            };
        }
        [Browsable(false)]
        public Person Person { get; set; }
    }
