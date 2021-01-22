    public class Test
    {
        public void HookupStuff()
        {
            List<Person> persons = new List<Person> { new Person() };
            this.EventHappened += new EventHandler(persons[0].SomeMethod);
            // persons[0].Sneezing += new EventHandler(Person_Sneezing);
    
            persons = null;
        }
    }
