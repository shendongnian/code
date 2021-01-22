    for (var flagIterator = 0; flagIterator < 32; flagIterator++)
    {
        // Determine the bit value (1,2,4,...,Int32.MinValue)
    	int bitValue = 1 << flagIterator;
    
        // Check to see if the current flag exists in the bit mask
        if ((intValue & bitValue) != 0)
        {
            // If the current flag exists in the enumeration, then we can add that value to the list
            // if the enumeration has that flag defined
            if (Enum.IsDefined(typeof(MyEnum), bitValue))
                Console.WriteLine((MyEnum)bitValue);
        }
    }
