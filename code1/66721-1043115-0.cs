    public class Node<T>
    {
        public void Visit(Action<T> action)
        {
            action(this);
            left.Visit(action);
            right.Visit(action);
        }
    
        public IEnumerable<Foo> GetAll ()
        {
            var result = new List<T>();
            Visit( n => result.Add(n));
            return result;
        }
    }
