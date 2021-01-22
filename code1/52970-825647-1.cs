    public static class PersonController
    {
        private static Person _Person;
        
        public static Person GetPerson()
        {
            if (_Person == null)
                _Person = new Person();
            
            return _Person;
        }
    }
