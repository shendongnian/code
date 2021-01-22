        public void Example()
        {
            var person = new Person
                             {
                                 GivenName = "John",
                                 FamilyName = "Smith",
                                 Address = new Address
                                               {
                                                   Street = "Wallace",
                                                   Number = 12
                                               },
                                 PhoneNumbers = new List<PhoneNumber>
                                                    {
                                                        new PhoneNumber
                                                            {
                                                                Number = 1234234,
                                                                AreaCode = 02
                                                            },
                                                        new PhoneNumber
                                                            {
                                                                Number = 1234234, AreaCode = 02
                                                            }
                                                    }
                             };
        }
        internal class PhoneNumber
        {
            public int AreaCode { get; set; }
            public int Number { get; set; }
        }
        internal class Address
        {
            public int Number { get; set; }
            public string Street { get; set; }
        }
        internal class Person
        {
            public Address Address { get; set; }
            public string GivenName { get; set; }
            public string FamilyName { get; set; }
            public List<PhoneNumber> PhoneNumbers { get; set; }
        }
    }
