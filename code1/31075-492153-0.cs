        public void myFunc(Enum e)
        {
            foreach (var name in Enum.GetNames(typeof(e)))
            {
                Console.WriteLine(name);
            }
        }
