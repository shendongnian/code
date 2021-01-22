    public static class ContactListExtensions
    {
        public static bool Contains<T>(this List<Person> contacts, string aPersonName)
        {
            //Then use any of the already suggested solutions like:
            return contacts.Contains(c => c.Name == aPersonName);
        }
    }  
