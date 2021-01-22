    public class EnumerablePair<T> : IReadOnlyCollection<T>
    {
        private IReadOnlyCollection<T> _Left;
        private IReadOnlyCollection<T> _Right;
        private IEnumerable<T> _Union;
        private int _Count;
        public EnumerablePair(IEnumerable<T> left, IEnumerable<T> right)
        {
            _Left = left?.ToList() ?? Enumerable.Empty<T>().ToList();
            _Right = right?.ToList() ?? Enumerable.Empty<T>().ToList();
            _Count = Left.Count + Right.Count;
            _Union = Left.Union(Right);
        }
    
        public int Count => _Count;
        public IReadOnlyCollection<T> Left { get => _Left; }
        public IReadOnlyCollection<T> Right { get => _Right; }
    
        public IEnumerator<T> GetEnumerator()
        {
            return _Union.GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _Union.GetEnumerator();
        }
    }
    
    public static class EnumerableExtension
    {
        public static EnumerablePair<T> ExclusiveDisjunction<T>(this IEnumerable<T> leftOperand, IEnumerable<T> rightOperand, IEqualityComparer<T> comparer = null)
        {
            if (leftOperand == null)
                throw new ArgumentNullException(nameof(leftOperand), $"{nameof(leftOperand)} is null.");
            if (rightOperand == null)
                throw new ArgumentNullException(nameof(rightOperand), $"{nameof(rightOperand)} is null.");
    
            // TODO : Can be optimized if one of the IEnumerable parameters is empty.
    
            bool leftIsBigger = leftOperand.Count() > rightOperand.Count();
            var biggestOperand = leftIsBigger ? leftOperand.ToList() : rightOperand.ToList();
            var smallestOperand = leftIsBigger ? rightOperand.ToList() : leftOperand.ToList();
    
            var except1 = biggestOperand.ToList();
            var except2 = Enumerable.Empty<T>().ToList();
    
            Func<T, T, bool> areEquals;
            if (comparer != null)
                areEquals = (one, theOther) => comparer.Equals(one, theOther);
            else
                areEquals = (one, theOther) => one?.Equals(theOther) ?? theOther == null;
    
            foreach (T t in smallestOperand)
                if (except1.RemoveAll(item => areEquals(item, t)) == 0)
                    except2.Add(t);
    
            if (leftIsBigger)
                return new EnumerablePair<T>(except1, except2);
            return new EnumerablePair<T>(except2, except1);
        }
    }
