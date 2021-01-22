    private T[] _elements;
    private int _index;
    
    public void Push(T item)
    {
        Scale(); // Dynamically grow the array as necessary.
        _elements[++_index] = item;
    }
    
    public T Pop()
    {
        if (_index == -1)
            throw InvalidOperationException();
    
        var item = _elements[_index];
        _elements[_index--] = null;
        return item;
    }
