    using System;
    namespace MVVMListAndDetailExample.Models
    {
        public class Person
        {
            static int nextId = 0;
            public Person()
            {
                Id = nextId++;
            }
            public int Id { get; private set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string City { get; set; }
            public string State { get; set; }
        }
    }
