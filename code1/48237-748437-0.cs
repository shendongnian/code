    public static T Remove<T>( this Stack<T> stack, T element )
    {
         T obj = stack.Pop();
         if (obj.Equals(element))
         {
             return obj;
         }
         else
         {
            T toReturn = stack.Remove( element );
            stack.Push(obj);
            return toReturn;
         }
    }
