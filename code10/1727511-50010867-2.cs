	class DownloadFileComparer : IEqualityComparer<DownloadFile>
	{
		public bool Equals(DownloadFile a, DownloadFile b)
		{
			return a.Address == b.Address;
		}
		
		public int GetHashCode(DownloadFile f)
		{
			return f.Address.GetHashCode();
		}
	}
