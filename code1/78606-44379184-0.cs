    public static class ExtensionMethods
    {
        public static List<T> FindAll<T> (this List<T> list, List<Predicate<T>> predicates)
        {
            List<T> L = new List<T> ();
            foreach (T item in list)
            {
				foreach (Predicate<T> p in predicates)
				{
					if (!(p (item))) break;
				}
				L.Add (item);
            }
            return L;
        }
    }
