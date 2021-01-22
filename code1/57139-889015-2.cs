    class Person : IEquatable<Person>
    {
        public string Name { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is Person)
            {
                Person other = (Person)obj;
                // check equality
            }
            return base.Equals(obj);
        }
        #region IEquatable<Person> Members
        public bool Equals(Person other)
        {
            // check equality without cast
        }
        #endregion
    }
