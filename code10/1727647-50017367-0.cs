       internal class Program
    {
        public static void Main(string[] args)
        {
            // Compiles, but is not what I need
            var firstHolder = new Holder()
            {
                TheList = { "A", "B" }
            };
            // Compiles, but initializes the list after object creation
            var existingList = new List<string>() { "Foo", "Bar" };
            var secondHolder = new Holder();
            secondHolder.TheList.AddRange(existingList);
            // Does not compile
            //var thirdHolder = new Holder()
            //{
            //    TheList =  existingList 
            //};
            //thirdHolder.TheList = existingList; // this is the traditional way
            var thirdHolder = Holder.HolderFactory(existingList);
        }
    }
    
    internal class Holder
    {
        public Holder()
        {
            TheList = new List<string>();
        }
        public static Holder HolderFactory(List<string> theList)
        {
            return new Holder(theList);
        }
        private Holder(List<string> theList)
        {
            this.TheList = theList;
        }
        public List<string> TheList { get; }
    }
