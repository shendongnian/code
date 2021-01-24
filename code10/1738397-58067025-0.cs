		public bool IsPagingEnabled
		{
			get
			{
				var pagingFileStrings = (string[])Registry.GetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management", "PagingFiles", null);
				if (pagingFileStrings == null)
					return false;
				foreach (var pagingFile in pagingFileStrings)
					if (pagingFile != null && !string.IsNullOrEmpty(pagingFile))
						return true;
				return false;
			}
		}
