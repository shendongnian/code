    public interface IEnumerationStrategy<TCollection, T>
    {
        IEnumerable<T> Enumerate(TCollection source);
    }
    public class Quark {}
    public class MyCollection
    {
        public IEnumerable<Quark> EnumerateAs(IEnumerationStrategy<MyCollection, Quark> strategy)
        {
            return strategy.Enumerate(this);
        }
        //Various special methods needed to implement stategies go here
    }
    public class SpecialStrategy : IEnumerationStrategy<MyCollection, Quark>
    {
        public IEnumerable<Quark> Enumerate(MyCollection source)
        {
            //Use special methods to do custom enumeration via yield return that depends on specifics of MyCollection
        }
    }
