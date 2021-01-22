    public class Creator
    {
        private class Person : IPerson
        {
            public string Name { get; set; }
        }
        public IPerson Create(...) ...
        
        public void Modify(IPerson person, ...)
        {
            Person dude = person as Person;
            if (dude == null)
                // wasn't created by this class.
            else
                // update the data.
        }
    }
