	class FileNameComparer: IEqualityComparer<String>
	{
		public bool Equals(String b1, String b2)
		{
			return Path.GetFileNameWithoutExtension(b1).Equals(Path.GetFileNameWithoutExtension(b2));
		}
		public int GetHashCode(String a)
		{
			return Path.GetFileNameWithoutExtension(a).GetHashCode();
		}
	}
