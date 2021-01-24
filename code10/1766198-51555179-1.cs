    // Adds the given object to the end of this list. The size of the list is
    // increased by one. If required, the capacity of the list is doubled
    // before adding the new element.
    //
    public void Add(T item) 
    {
       if (_size == _items.Length) EnsureCapacity(_size + 1);
          _items[_size++] = item;
       _version++;
     }
