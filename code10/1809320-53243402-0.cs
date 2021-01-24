        public class pet
        {
            public string name { get; set; }
            private DateTime _dateOfBirth { get; set; } //<~~ Issue is with this property
            [XmlElement("dateOfBirth")]
            public string DateOfBirth
            {
                get { return _dateOfBirth.ToString("yyyy-MM-dd"); }
                set { _dateOfBirth = DateTime.ParseExact(value, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture); }
            }
                   
        }
