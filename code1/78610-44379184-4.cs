    public static class ExtensionMethods
    {
        public static List<T> FindAll<T> (this List<T> list, List<Predicate<T>> predicates)
        {
            List<T> L = new List<T> ();
            foreach (T item in list)
            {
                bool pass = true;
				foreach (Predicate<T> p in predicates)
				{
					if (!(p (item)))
                    {
                        pass = false;
                        break;
                    }
				}
				if (pass) L.Add (item);
            }
            return L;
        }
    }
