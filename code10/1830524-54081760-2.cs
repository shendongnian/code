        public enum MyEnum
        {
            First,
            Second,
            Third
        }
        private void EnumValues()
        {
            Array values = Enum.GetValues(typeof(MyEnum));
            foreach (MyEnum val in values)
            {
                //// To print name and value in enum
                Console.WriteLine(String.Format("{0}: {1}", Enum.GetName(typeof(MyEnum), val), val));
                //// To get only value
                int i = (int)val;
            }
        }
