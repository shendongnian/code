    public static class StackExtensions
    {
        public static void Remove<T>(this Stack<T> myStack, ICollection<T> elementsToRemove)
        {
            var reversedStack = new Stack<T>();
            while(myStack.Count > 0)
            {
                var topItem = myStack.Pop();
                if (!elementsToRemove.Contains(topItem))
                {
                    reversedStack.Push(topItem);
                }
            }
            while(reversedStack.Count > 0)
            {
                myStack.Push(reversedStack.Pop());
            }           
        }
    }
