	/// <summary>
	/// Collection Helper
	/// </summary>
	/// <remarks>
	/// Use IEnumerable by default, but when altering or getting item at index use IList.
	/// </remarks>
	public static class CollectionHelper
	{
		#region Alter;
		/// <summary>
		/// Swap item to another place
		/// </summary>
		/// <typeparam name="T">Collection type</typeparam>
		/// <param name="this">Collection</param>
		/// <param name="IndexA">Index a</param>
		/// <param name="IndexB">Index b</param>
		/// <returns>New collection</returns>
		public static IList<T> Swap<T>(this IList<T> @this, Int32 IndexA, Int32 IndexB)
		{
			T Temp = @this[IndexA];
			@this[IndexA] = @this[IndexB];
			@this[IndexB] = Temp;
			return @this;
		}
		/// <summary>
		/// Swap item to the left
		/// </summary>
		/// <typeparam name="T">Collection type</typeparam>
		/// <param name="this">Collection</param>
		/// <param name="Index">Index</param>
		/// <returns>New collection</returns>
		public static IList<T> SwapLeft<T>(this IList<T> @this, Int32 Index)
		{
			return @this.Swap(Index, Index - 1);
		}
		/// <summary>
		/// Swap item to the right
		/// </summary>
		/// <typeparam name="T">Collection type</typeparam>
		/// <param name="this">Collection</param>
		/// <param name="Index">Index</param>
		/// <returns>New collection</returns>
		public static IList<T> SwapRight<T>(this IList<T> @this, Int32 Index)
		{
			return @this.Swap(Index, Index + 1);
		}
		#endregion Alter;
		#region Action;
		/// <summary>
		/// Execute action at specified index
		/// </summary>
		/// <typeparam name="T">Collection type</typeparam>
		/// <param name="this">Collection</param>
		/// <param name="Index">Index</param>
		/// <param name="ActionAt">Action to execute</param>
		/// <returns>New collection</returns>
		public static IList<T> ActionAt<T>(this IList<T> @this, Int32 Index, Action<T> ActionAt)
		{
			ActionAt(@this[Index]);
			return @this;
		}
		#endregion Action;
		#region Randomize;
		/// <summary>
		/// Take random items
		/// </summary>
		/// <typeparam name="T">Collection type</typeparam>
		/// <param name="this">Collection</param>
		/// <param name="Count">Number of items to take</param>
		/// <returns>New collection</returns>
		public static IEnumerable<T> TakeRandom<T>(this IEnumerable<T> @this, Int32 Count)
		{
			return @this.Shuffle().Take(Count);
		}
		/// <summary>
		/// Take random item
		/// </summary>
		/// <typeparam name="T">Collection type</typeparam>
		/// <param name="this">Collection</param>
		/// <returns>Item</returns>
		public static T TakeRandom<T>(this IEnumerable<T> @this)
		{
			return @this.TakeRandom(1).Single();
		}
		/// <summary>
		/// Shuffle list
		/// </summary>
		/// <typeparam name="T">Collection type</typeparam>
		/// <param name="this">Collection</param>
		/// <returns>New collection</returns>
		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> @this)
		{
			return @this.OrderBy(Item => Guid.NewGuid());
		}
		#endregion Randomize;
		#region Navigate;
		/// <summary>
		/// Get next item in collection and give first item, when last item is selected;
		/// </summary>
		/// <typeparam name="T">Collection type</typeparam>
		/// <param name="this">Collection</param>
		/// <param name="Index">Index in collection</param>
		/// <returns>Next item</returns>
		public static T Next<T>(this IList<T> @this, ref Int32 Index)
		{
			Index = ++Index >= 0 && Index < @this.Count ? Index : 0;
			return @this[Index];
		}
		/// <summary>
		/// Get previous item in collection and give last item, when first item is selected;
		/// </summary>
		/// <typeparam name="T">Collection type</typeparam>
		/// <param name="this">Collection</param>
		/// <param name="Index">Index in collection</param>
		/// <returns>Previous item</returns>
		public static T Previous<T>(this IList<T> @this, ref Int32 Index)
		{
			Index = --Index >= 0 && Index < @this.Count ? Index : @this.Count - 1;
			return @this[Index];
		}
		#endregion Navigate;
		#region Clone;
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T">Collection type</typeparam>
		/// <param name="this">Collection</param>
		/// <returns>Cloned collection</returns>
		public static IEnumerable<T> Clone<T>(this IEnumerable<T> @this) where T : ICloneable
		{
			return @this.Select(Item => (T)Item.Clone());
		}
		#endregion Clone;
		#region String;
		/// <summary>
		/// Joins multiple string with Separator
		/// </summary>
		/// <param name="this">Collection</param>
		/// <param name="Separator">Separator</param>
		/// <returns>Joined string</returns>
		public static String Join(this IEnumerable<String> @this, String Separator = "")
		{
			return String.Join(Separator, @this);
		}
		#endregion String;
	}
