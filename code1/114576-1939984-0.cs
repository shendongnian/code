        public IEnumerable<string> Names
        {
            get
            {
                foreach (Person p in persons)
                {
                    yield return p.Name;
                }
            }
        }
