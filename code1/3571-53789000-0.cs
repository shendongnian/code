    //
    // Summary:
    //     Exposes an enumerator, which supports a simple iteration over a non-generic collection.
    public interface IEnumerable
    {
        //
        // Summary:
        //     Returns an enumerator that iterates through a collection.
        //
        // Returns:
        //     An System.Collections.IEnumerator object that can be used to iterate through
        //     the collection.
        IEnumerator GetEnumerator();
    }
    //
    // Summary:
    //     Supports a simple iteration over a non-generic collection.
    public interface IEnumerator
    {
        //
        // Summary:
        //     Gets the element in the collection at the current position of the enumerator.
        //
        // Returns:
        //     The element in the collection at the current position of the enumerator.
        object Current { get; }
    
        //
        // Summary:
        //     Advances the enumerator to the next element of the collection.
        //
        // Returns:
        //     true if the enumerator was successfully advanced to the next element; false if
        //     the enumerator has passed the end of the collection.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     The collection was modified after the enumerator was created.
        bool MoveNext();
        //
        // Summary:
        //     Sets the enumerator to its initial position, which is before the first element
        //     in the collection.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     The collection was modified after the enumerator was created.
        void Reset();
    }
