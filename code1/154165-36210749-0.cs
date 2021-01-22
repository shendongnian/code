    public class SequenceComparer<TElement> : Comparer<IEnumerable<TElement>>
    {
        private readonly IComparer<TElement> _elementComparer;
        public SequenceComparer(IComparer<TElement> elementComparer = null)
        {
            _elementComparer = elementComparer ?? Comparer<TElement>.Default;
        }
        
        public override int Compare(IEnumerable<TElement> x, IEnumerable<TElement> y)
        {
            // Get enumerators to iterate over both sequences in sync.
            using (IEnumerator<TElement> xEnumerator = x.GetEnumerator())
            using (IEnumerator<TElement> yEnumerator = y.GetEnumerator())
            {
                // Advance both enumerators to their next element, 
                // until at least one passes the end of its sequence.
                bool xMove, yMove;
                while ((xMove = xEnumerator.MoveNext()) &&
                       (yMove = yEnumerator.MoveNext()))
                {
                    // Compare the current pair of elements across the two sequences,
                    // seeking element inequality.
                    int elementComparison = _elementComparer.Compare(xEnumerator.Current, yEnumerator.Current);
                    if (elementComparison != 0)
                        return elementComparison;
                }
                // Determine the relative length of the two sequences based on the final values of xMove and yMove.
                return xMove.CompareTo(yMove);
            }
        }
    }
