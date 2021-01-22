    using System;
    namespace EqualityWithBiDirectionalAssociation
    {
        public class Person : IEquatable<Person>
        {
            private string _firstName;
            private string _lastName;
            private Address _address;
            public Person(string firstName, string lastName, Address address)
            {
                FirstName = firstName;
                LastName = lastName;
                Address = address;
            }
            public virtual Address Address
            {
                get { return _address; }
                set { _address = value; }
            }
            public virtual string FirstName
            {
                get { return _firstName; }
                set { _firstName = value; }
            }
            public virtual string LastName
            {
                get { return _lastName; }
                set { _lastName = value; }
            }
            public override bool Equals(object obj)
            {
                // Use 'as' rather than a cast to get a null rather an exception
                // if the object isn't convertible
                Person person = obj as Person;
                return this.Equals(person);
            }
            public override int GetHashCode()
            {
                string composite = FirstName + LastName;
                return composite.GetHashCode();
            }
            internal virtual bool EqualsIgnoringAddress(Person other)
            {
                // Per MSDN documentation, x.Equals(null) should return false
                if ((object)other == null)
                {
                    return false;
                }
                return ( this.FirstName.Equals(other.FirstName)
                    && this.LastName.Equals(other.LastName));
            }
            #region IEquatable<Person> Members
            public virtual bool Equals(Person other)
            {
                // Per MSDN documentation, x.Equals(null) should return false
                if ((object)other == null)
                {
                    return false;
                }
                return (this.Address.EqualsIgnoringPerson(other.Address)   // Don't have Address check it's person
                    && this.FirstName.Equals(other.FirstName)
                    && this.LastName.Equals(other.LastName));
            }
            #endregion
        }
        public class Address : IEquatable<Address>
        {
            private string _streetName;
            private string _city;
            private string _state;
            private Person _resident;
            public Address(string city, string state, string streetName)
            {
                City = city;
                State = state;
                StreetName = streetName;
                _resident = null;
            }
            public virtual string City
            {
                get { return _city; }
                set { _city = value; }
            }
            public virtual Person Resident
            {
                get { return _resident; }
                set { _resident = value; }
            }
            public virtual string State
            {
                get { return _state; }
                set { _state = value; }
            }
            public virtual string StreetName
            {
                get { return _streetName; }
                set { _streetName = value; }
            }
            public override bool Equals(object obj)
            {
                // Use 'as' rather than a cast to get a null rather an exception
                // if the object isn't convertible
                Address address = obj as Address;
                return this.Equals(address);
            }
            public override int GetHashCode()
            {
                string composite = StreetName + City + State;
                return composite.GetHashCode();
            }
            internal virtual bool EqualsIgnoringPerson(Address other)
            {
                // Per MSDN documentation, x.Equals(null) should return false
                if ((object)other == null)
                {
                    return false;
                }
                return (this.City.Equals(other.City)
                    && this.State.Equals(other.State)
                    && this.StreetName.Equals(other.StreetName));
            }
            #region IEquatable<Address> Members
            public virtual bool Equals(Address other)
            {
                // Per MSDN documentation, x.Equals(null) should return false
                if ((object)other == null)
                {
                    return false;
                }
                return (this.City.Equals(other.City)
                    && this.State.Equals(other.State)
                    && this.StreetName.Equals(other.StreetName)
                    && this.Resident.EqualsIgnoringAddress(other.Resident));
            }
            #endregion
        }
        public class Program
        {
            static void Main(string[] args)
            {
                Address address1 = new Address("seattle", "washington", "Awesome St");
                Address address2 = new Address("seattle", "washington", "Awesome St");
                Person person1 = new Person("John", "Doe", address1);
                address1.Resident = person1;
                address2.Resident = person1;
                if (address1.Equals(address2)) // <-- No stack overflow!
                {
                    Console.WriteLine("The two addresses are equal");
                }
                Person person2 = new Person("John", "Doe", address2);
                address2.Resident = person2;
                if (address1.Equals(address2)) // <-- No a stack overflow!
                {
                    Console.WriteLine("The two addresses are equal");
                }
                Console.Read();
            }
        }
    }
