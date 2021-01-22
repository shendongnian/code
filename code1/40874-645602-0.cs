    public class Contact
    {
        public virtual int Id {get;set;}
        ..
    
        private ISet<Phonenumber> _phoneNumbers = new HashedSet<PhoneNumber>();
    
        public ReadOnlyCollection<Phonenumber> PhoneNumbers
        {
            get 
            {
               return new List<Phonenumber>(_phoneNumbers).AsReadOnly();
            }
        }
    
        public void AddPhonenumber( Phonenumber n )  
        {
            n.Contact = this;
            _phoneNumbers.Add(n);
        }
    
        public void RemovePhoneNumber( PhoneNumber n )
        {
            ...
        }
    }
