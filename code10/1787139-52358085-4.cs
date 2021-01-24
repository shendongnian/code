    using System;
    namespace Test.Models
    {
        public class UserInfo
        {
            public String Name { get; set; }
            public String Age { get; set; }
            public String Location { get; set; }
            public String DisplayInfo => "Name: " + Name + " Age: " + Age + " Location: " + Location;
        }
    }
