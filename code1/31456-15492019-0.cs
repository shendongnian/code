	using System.Collections.Generic;
	public static class Extensions {
		//=========================================================================
		// Removes all instances of [itemToRemove] from array [original]
		// Returns the new array, without modifying [original] directly
		// .Net2.0-compatible
		public static T[] RemoveFromArray<T> (this T[] original, T itemToRemove) {	
			int numIdx = System.Array.IndexOf(original, itemToRemove);
			if (numIdx == -1) return original;
			List<T> tmp = new List<T>(original);
			tmp.RemoveAt(numIdx);
			return tmp.ToArray();
		}
	}
