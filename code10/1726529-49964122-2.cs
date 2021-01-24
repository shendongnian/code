     public static class ExtensionMethods
     {
        public static int FindAndRemove(this List<string[]> list, string[] items)
        {
            return list.RemoveAll(arr => arr.SequenceEqual(items));
        }
     }
