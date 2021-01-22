    public static class SomethingFactory
    {
        private static List<Something> listOfSomethings = new List<Something>();
    
        public staic Something CreateSomething()
        {
            something = new Something();
            listOfSomethings.Add(something);
            return something;
        }
    }
