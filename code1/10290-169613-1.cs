    class MyCollection : ICollection<T> {
       void ICollection<T>.CopyTo(T[] array, int index) {
           // Bounds checking, etc here.
           CopyToImpl(array, index);
       }
       void ICollection.CopyTo(Array array, int index) {
           // Bounds checking, etc here.
           if (array is T[]) { // quick, avoids reflection, but only works if array is typed as exactly T[]
               CopyToImpl((T[])localArray, index);
           } else {
               Type elementType = array.GetType().GetElementType();
               if (!elementType.IsAssignableFrom(typeof(T)) && !typeof(T).IsAssignableFrom(elementType)) {
                   throw new Exception();
               }
               CopyToImpl((object[])array, index);
           }
       }
       private void CopyToImpl(object[] array, int index) {
           // array will always have a valid type by this point, and the bounds will be checked
           // Handle the copying here
       }
    }
