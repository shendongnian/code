    static class StackExtensions
    {
        public static T PopOrDefault<T>(this Stack<T> stack)
        {
            if (stack.Count == 0) return default(T);
            return stack.Pop();
        }
    }
