      public static class ArrayExtensions
        {
            /// <summary>
            /// Removes the last element.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="array">The array.</param>
            /// <returns>T[].</returns>
            public static T[] RemoveLastElement<T>(this T[] array)
            {
                var stack = new Stack<T>(array);
                stack.Pop();
                return stack.ToArray().Reverse().ToArray();
            }
    
            /// <summary>
            /// Removes the first element.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="array">The array.</param>
            /// <returns>T[].</returns>
            public static T[] RemoveFirstElement<T>(this T[] array)
            {
                var queue = new Queue<T>(array);
                queue.Dequeue();
                return queue.ToArray();
            }
        }
