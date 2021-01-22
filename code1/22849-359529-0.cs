        public IEnumerable<Person> Get()
        {
            foreach (Person p in l1)
            {
                yield return p.Clone();
            }
        }
