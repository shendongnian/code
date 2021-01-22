    public class WidgetBox<A,B,C> where B : IEquatable<B>
    {
        public bool ContainsB(B b)
        {
            // Iterating thru a collection of B's
            if( b.Equals(iteratorB) )
            ...
        }
    }
