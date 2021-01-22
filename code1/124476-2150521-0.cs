    public class CellPhone 
    {
        private Phone _phone;
        private Pda _pda;
    
        public CellPhone(Phone phone, Pda pda)
        {
            _phone = phone;
            _pda = pda;
        }
    
        public IPhone getPhone()
        {
            return _phone;
        }
    
        public IPda getPda()
        {
            return _pda;
        }
    
        public void MakeCall(string contactName) {
            int phoneNumber = _pda.LookUpContactPhoneNumber(contactName);
            _phone.MakeCall(phoneNumber);
        }
    
    }
