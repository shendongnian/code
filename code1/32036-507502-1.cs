        public void myFunc<T>()
        {
            var names = Enum.GetNames(typeof(T));
            foreach (var name in names)
            {
                // do something!
            }
        }
