        public class FooDisplayViewModel // use for "details" view
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            [DataType("EmailAddress")]
            public string EmailAddress { get; set; }
            public int Age { get; set; }
            [DisplayName("Category")]
            public string CategoryName { get; set; }
        }
