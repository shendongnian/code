		public static Random randomizer = new Random(); // you'd ideally be able to replace this with whatever makes you comfortable
		public static IEnumerable<T> GetRandom<T>(this IEnumerable<T> list, int numItems) {
			return (list as T[] ?? list.ToArray()).GetRandom(numItems);
			// because ReSharper whined about duplicate enumeration...
			/*
			items.Add(list.ElementAt(randomizer.Next(list.Count()))) ) numItems--;
			*/
		}
		// just because the parentheses were getting confusing
		public static IEnumerable<T> GetRandom<T>(this T[] list, int numItems) {
			var items = new HashSet<T>(); // don't want to add the same item twice; otherwise use a list
			while (numItems > 0 )
				// if we successfully added it, move on
				if( items.Add(list[randomizer.Next(list.Length)]) ) numItems--;
			return items;
		}
		// and because it's really fun; note -- you may get repetition
		public static IEnumerable<T> PluckRandomly<T>(this IEnumerable<T> list) {
			while( true )
				yield return list.ElementAt(randomizer.Next(list.Count()));
		}
	}
