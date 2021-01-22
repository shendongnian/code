    public interface IDeepCloneable<T>
    {
        T DeepClone();
    }
    public class Person : IDeepCloneable<Person> 
    {
        public string Name { get; set; }
        public IList<Address> Addresses { get; set; }
        public Person DeepClone()
        {
            var clone = new Person() { Name = Name.Clone().ToString() };
            //have to make a clone of each child 
            var addresses = new List<Address>();
            foreach (var address in this.Addresses)
                addresses.Add(address.DeepClone());
            clone.Addresses = addresses;
            return clone;
        }
    }
    public class Address : IDeepCloneable<Address>
    {
        public int StreetNumber { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        
        public Address DeepClone()
        {
            var clone = new Address()
                            {
                                Street = this.Street.Clone().ToString(),
                                StreetNumber = this.StreetNumber, //value type - no reference held
                                Suburb = this.Suburb.Clone().ToString()
                            };
            return clone;
        }
    }
    //usage:
    var source = personRepository.FetchByName("JoeBlogs1999");
    var target = source.DeepClone();
    //at this point you could set any statuses, or non cloning related changes to the copy etc..
    targetRepository.Add(target);
    targetRepository.Update;
