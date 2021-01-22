        public static IEnumerable<T> SelectRecursive<T>(this IEnumerable<T> rootItems, Func<T, IEnumerable<T>> selector)
        {
            return new RecursiveEnumerable<T>(rootItems, selector, false);
        }
        public static IEnumerable<T> SelectRecursiveReverse<T>(this IEnumerable<T> rootItems, Func<T, IEnumerable<T>> selector)
        {
            return new RecursiveEnumerable<T>(rootItems, selector, true);
        }
        class RecursiveEnumerable<T> : IEnumerable<T>
        {
            public RecursiveEnumerable(IEnumerable<T> rootItems, Func<T, IEnumerable<T>> selector, bool reverse)
            {
                _rootItems = rootItems;
                _selector = selector;
                _reverse = reverse;
            }
            IEnumerable<T> _rootItems;
            Func<T, IEnumerable<T>> _selector;
            bool _reverse;
            public IEnumerator<T> GetEnumerator()
            {
                return new Enumerator(this);
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            class Enumerator : IEnumerator<T>
            {
                public Enumerator(RecursiveEnumerable<T> owner)
                {
                    _owner = owner;
                    Reset();
                }
                RecursiveEnumerable<T> _owner;
                T _current;
                Stack<IEnumerator<T>> _stack = new Stack<IEnumerator<T>>();
                public T Current
                {
                    get 
                    {
                        if (_stack == null || _stack.Count == 0)
                            throw new InvalidOperationException();
                        return _current; 
                    }
                }
                public void Dispose()
                {
                    _current = default(T);
                    if (_stack != null)
                    {
                        while (_stack.Count > 0)
                        {
                            _stack.Pop().Dispose();
                        }
                        _stack = null;
                    }
                }
                object System.Collections.IEnumerator.Current
                {
                    get { return Current; }
                }
                public bool MoveNext()
                {
                    if (_owner._reverse)
                        return MoveReverse();
                    else
                        return MoveForward();
                }
                public bool MoveForward()
                {
                    // First time?
                    if (_stack == null)
                    {
                        // Setup stack
                        _stack = new Stack<IEnumerator<T>>();
                        // Start with the root items
                        _stack.Push(_owner._rootItems.GetEnumerator());
                    }
                    // Process enumerators on the stack
                    while (_stack.Count > 0)
                    {
                        // Get the current one
                        var se = _stack.Peek();
                        // Next please...
                        if (se.MoveNext())
                        {
                            // Store it
                            _current = se.Current;
                            // Get child items
                            var childItems = _owner._selector(_current);
                            if (childItems != null)
                            {
                                _stack.Push(childItems.GetEnumerator());
                            }
                            return true;
                        }
                        // Finished with the enumerator
                        se.Dispose();
                        _stack.Pop();
                    }
                    // Finished!
                    return false;
                }
                public bool MoveReverse()
                {
                    // First time?
                    if (_stack == null)
                    {
                        // Setup stack
                        _stack = new Stack<IEnumerator<T>>();
                        // Start with the root items
                        _stack.Push(_owner._rootItems.Reverse().GetEnumerator());
                    }
                    // Process enumerators on the stack
                    while (_stack.Count > 0)
                    {
                        // Get the current one
                        var se = _stack.Peek();
                        // Next please...
                        if (se.MoveNext())
                        {
                            // Get child items
                            var childItems = _owner._selector(se.Current);
                            if (childItems != null)
                            {
                                _stack.Push(childItems.Reverse().GetEnumerator());
                                continue;
                            }
                            // Store it
                            _current = se.Current;
                            return true;
                        }
                        // Finished with the enumerator
                        se.Dispose();
                        _stack.Pop();
                        if (_stack.Count > 0)
                        {
                            _current = _stack.Peek().Current;
                            return true;
                        }
                    }
                    // Finished!
                    return false;
                }
                public void Reset()
                {
                    Dispose();
                }
            }
        }
