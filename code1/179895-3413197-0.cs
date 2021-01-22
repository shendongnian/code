    class MergeEnumerable<T> : IEnumerable<T>
        {
            public IEnumerator<T> GetEnumerator()
            {
                var left = _left.GetEnumerator();
                var right = _right.GetEnumerator();
                var leftHasSome = left.MoveNext();
                var rightHasSome = right.MoveNext();
                while (leftHasSome || rightHasSome)
                {
                    if (leftHasSome && rightHasSome)
                    {
                      if(_comparer.Compare(left.Current,right.Current) < 0)
                      {
                        yield return returner(left);
                      } else {
                        yield return returner(right);
                      }
                    }
                    else if (rightHasSome)
                    {
                        returner(right);
                    }
                    else
                    {
                        returner(left);
                    }
                }
            }
    
            private T returner(IEnumerator<T> enumerator)
            {
                var current = enumerator.Current;
                enumerator.MoveNext();
                return current;
            }
    
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return ((IEnumerable<T>)this).GetEnumerator();
            }
    
            private IEnumerable<T> _left;
            private IEnumerable<T> _right;
            private IComparer<T> _comparer;
    
            MergeEnumerable(IEnumerable<T> left, IEnumerable<T> right, IComparer<T> comparer)
            {
                _left = left;
                _right = right;
                _comparer = comparer;
            }
        }
