        public override bool IsValid(object value)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value);
            // Get the values of the properties we need. 
            // Alternatively, we don't need to hard code the property names,
            // and instead define them via the attribute constructor
            object prop1Value = properties.Find("Person", true).GetValue(value);
            object prop2Value = properties.Find("City", true).GetValue(value);
            object prop3Value = properties.Find("Country", true).GetValue(value);
            // We can cast the values we received to anything
            Person person = (Person)prop1value; 
            City city = (Person)prop2value;
            Country country = (Person)prop3value;
            // Now we can manipulate the values, running any type of logic tests on them
            if(person.Name.Equals("Baddie") && city.ZIP == 123456)
            {
                return country.name.Equals("Australia");
            }
            else
            {
                return false;
            }         
        }
