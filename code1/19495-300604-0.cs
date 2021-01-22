        private Dictionary<String, Type> _objectTypes = new Dictionary<String, Type>();
        public ObjectFactory()
        {
            // Preload the Object Types into a dictionary so we can look them up later
            foreach (Type type in typeof(ObjectFactory).Assembly.GetTypes())
            {
                if (type.IsSubclassOf(typeof(BaseEntity)))
                {
                    _objectTypes[type.Name.ToLower()] = type;
                }
            }
        }
