    class Printer
    {
        public Printer(IEnumerable<IPrintable> list) //Accepts any collection with an object that implements IPrintable interface
        {
            foreach (var enumerable in list) //iterate through list of objects
            {
                foreach (var printable in enumerable)//loops through properties in current object
                {
                    //DO STUFF 
                }
            }
        }
    }
    interface IPrintable : IEnumerable { }
    class SomeObject : IPrintable
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
    
        public interface IEnumerable
        {
            IEnumerator GetEnumerator(); //Returns a Enumerator
        }
    
        public IEnumerator GetEnumerator()
        {
            yield return Property1;
            yield return Property2;
        }
    }
