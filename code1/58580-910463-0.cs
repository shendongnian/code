    public class Person
    {
        private Name name = Name.Empty;
        private Address address = Address.Empty;
        private bool canMove;
        
        public Name Name
        {
            set { name = value; }
            get { return name; }
        }
        public Address Address
        {
            private set { address = value; }
            get { return address; }
        }
        public bool CanMove
        {
            set { canMove = value; }
            get { return value; }
        }
        public bool MoveToNewAddress(Address newAddress)
        {
            if (!CanMove) return false;
            address = newAddress;
            return true;
        }
    }
    [TestFixture]
    public class PersonTests
    {
        private Person toTest;
        private readonly static Name NAME = new Name { First = "Charlie", Last = "Brown" };
        private readonly static Address ADDRESS =
            new Address {
                Line1 = "1600 Pennsylvania Ave NW",
                City = "Washington",
                State = "DC",
                ZipCode = "20500" };
        [SetUp]
        public void SetUp()
        {
            toTest = new Person;
        }
        [Test]
        public void NameDefaultsToEmpty()
        {
            Assert.AreEqual(Name.Empty, toTest.Name);
        }
        [Test]
        public void CanMoveDefaultsToTrue()
        {
            Assert.AreEqual(true, toTest.CanMove);
        }
        [Test]
        public void AddressDefaultsToEmpty()
        {
            Assert.AreEqual(Address.Empty, toTest.Address);
        }
        [Test]
        public void NameIsSet()
        {
            toTest.Name = NAME;
            Assert.AreEqual(NAME, toTest.Name);
        }
        [Test]
        public void CanMoveIsSet()
        {
            toTest.CanMove = false;
            Assert.AreEqual(false, toTest.CanMove);
        }
        [Test]
        public void AddressIsChanged()
        {
            Assert.IsTrue(toTest.MoveToNewAddress(ADDRESS));
            Assert.AreEqual(ADDRESS, toTest.Address);
        }
        [Test]
        public void AddressIsNotChanged()
        {
            toTest.CanMove = false;
            Assert.IsFalse(toTest.MoveToNewAddress(ADDRESS));
            Assert.AreNotEqual(ADDRESS, toTest.Address);
        }
    }
