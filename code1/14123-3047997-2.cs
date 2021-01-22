    public static unsafe string Reverse(string text)
    {
        int len = text.Length;
        
        // Why allocate a char[] array on the heap when you won't use it
        // outside of this method? Use the stack.
        char* reversed = stackalloc char[len];
        
        // Avoid bounds-checking performance penalties.
        fixed (char* str = text)
        {
            int i = 0;
            int j = i + len - 1;
            while (i < len)
            {
                reversed[i++] = str[j--];
            }
        }
        
        // Need to use this overload for the System.String constructor
        // as providing just the char* pointer could result in garbage
        // at the end of the string (no guarantee of null terminator).
        return new string(reversed, 0, len);
    }
