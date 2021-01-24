    public static class ExtensionMethods
    {
        public static string[] FindAndRemove(this ICollection<string[]> list, string[] items)
        {
            string[] removedList = null;
            foreach (var stringArray in list)
            {
                if (stringArray.SequenceEqual(items))
                {
                    removedList = stringArray;
                    break;
                }
            }
            if (removedList != null)
            {
                list.Remove(removedList);
            }
            return removedList;
        }
    }
