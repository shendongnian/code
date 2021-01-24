    public class Book : IEquatable<Book>
	{
		public string BookName { get; }
		public Dictionary<string, string> BookDictionary { get; }
		public Book(string bookName, Dictionary<string, string> bookDictionary)
		{
			this.BookName = bookName;
			this.BookDictionary = bookDictionary;
		}
		public bool Equals(Book other)
		{
			if (ReferenceEquals(null, other))
			{
				return false;
			}
			if (ReferenceEquals(this, other))
			{
				return true;
			}
			if (!string.Equals(BookName, other.BookName))
				return false;
			if (BookDictionary.Count != other.BookDictionary.Count)
				return false;
			return BookDictionary.All(kv => other.BookDictionary.ContainsKey(kv.Value) 
                                         && other.BookDictionary[kv.Key] == kv.Value);
		}
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}
			if (ReferenceEquals(this, obj))
			{
				return true;
			}
			if (obj.GetType() != this.GetType())
			{
				return false;
			}
			return Equals((Book) obj);
		}
		public override int GetHashCode()
		{
			unchecked
			{
				int dictHash = 17;
				foreach (KeyValuePair<string, string> kv in this.BookDictionary)
				{
					dictHash = dictHash * 23 + kv.Key.GetHashCode();
					dictHash = dictHash * 23 + (kv.Value ?? "").GetHashCode();
				}
				return ((BookName != null ? BookName.GetHashCode() : 0) * 397) ^ dictHash;
			}
		}
	}
