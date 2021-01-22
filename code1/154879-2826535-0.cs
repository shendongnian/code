    // Reallocates an array with a new size, and copies the contents
    // of the old array to the new array.
    // Arguments:
    //   oldArray  the old array, to be reallocated.
    //   newSize   the new array size.
    // Returns     A new array with the same contents.
    public static System.Array ResizeArray (System.Array oldArray, int newSize) {
       int oldSize = oldArray.Length;
       System.Type elementType = oldArray.GetType().GetElementType();
       System.Array newArray = System.Array.CreateInstance(elementType,newSize);
       int preserveLength = System.Math.Min(oldSize,newSize);
       if (preserveLength > 0)
          System.Array.Copy (oldArray,newArray,preserveLength);
       return newArray; 
}
