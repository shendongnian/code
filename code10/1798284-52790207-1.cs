    public static int DoStuffSafely( int[] values, int valueToRemove, int length )
    {
        var newLength = 0;
        // ~13.5% slower than @TheGeneral's unsafe implementation
        foreach( var v in values )
        {
            // if the value matches the value to remove, skip it
            if( valueToRemove != v )
            {
                // newLength tracks the length of the "new" array
                // we'll set the value at that index
                values[ newLength ] = v;
                // then increase the length of the "new" array
                ++newLength;
                // I never use post-increment/decrement operators
                // it requires a temp memory alloc that we toss immediately
                // which is expensive for this simple loop, adds about 11% in execution time
            }
        }
        return newLength;
    }
