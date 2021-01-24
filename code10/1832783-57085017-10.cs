    using System;
    using System.Collections.Generic;
    namespace MVVMListAndDetailExample.Models
    {
        public class People
        {
            private static readonly object padlock = new object();
            static People instance = null;
            public static People Instance
            {
                get
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new People();
                        }
                        return instance;
                    }
                }
            }
        
            private People()
            {
                PeopleList = new List<Person>();
                PeopleList.Add(new Person
                {
                    FirstName = "John",
                    LastName = "Smith",
                    Age = 25,
                    City = "New York City",
                    State = "NY"
                });
                PeopleList.Add(new Person
                {
                    FirstName = "Frank",
                    LastName = "Lee",
                    Age = 35,
                    City = "San Francisco",
                    State = "CA"
                });
                PeopleList.Add(new Person
                {
                    FirstName = "Jessie",
                    LastName = "Lane",
                    Age = 45,
                    City = "Chicago",
                    State = "IL"
                });
                PeopleList.Add(new Person
                {
                    FirstName = "Susan",
                    LastName = "Jones",
                    Age = 55,
                    City = "Seattle",
                    State = "WA"
                });
                PeopleList.Add(new Person
                {
                    FirstName = "Greg",
                    LastName = "Franklin",
                    Age = 65,
                    City = "Atlanta",
                    State = "GA"
                });
                PeopleList.Add(new Person
                {
                    FirstName = "Howard",
                    LastName = "Waters",
                    Age = 75,
                    City = "Tampa",
                    State = "FL"
                });
            }
            public List<Person> PeopleList { get; private set; }
               
        }
    }
