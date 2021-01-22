	internal class Program
	{
		private static readonly ExtendedPropertyDefinition PidTagMessageSizeExtended = new ExtendedPropertyDefinition(0xe08,
		                                                                                                              MapiPropertyType
		                                                                                                              	.Long);
		public static void Main(string[] args)
		{
			var service = new ExchangeService(ExchangeVersion.Exchange2010_SP1)
			              {Credentials = new NetworkCredential("mail", "pw!")};
			service.AutodiscoverUrl("mail", url => true);
			var offset = 0;
			const int pagesize = 12;
			long size = 0;
			FindFoldersResults folders;
			do
			{
				folders = service.FindFolders(WellKnownFolderName.MsgFolderRoot,
				                              new FolderView(pagesize, offset, OffsetBasePoint.Beginning)
				                              {
				                              	Traversal = FolderTraversal.Deep,
				                              	PropertySet =
				                              		new PropertySet(BasePropertySet.IdOnly, PidTagMessageSizeExtended,
				                              		                FolderSchema.DisplayName)
				                              });
				foreach (var folder in folders)
				{
					long folderSize;
					if (folder.TryGetProperty(PidTagMessageSizeExtended, out folderSize))
					{
						Console.Out.WriteLine("{0}: {1:00.00} MB", folder.DisplayName, folderSize/1048576);
						size += folderSize;
					}
				}
				offset += pagesize;
			} while (folders.MoreAvailable);
			Console.Out.WriteLine("size = {0:0.00} MB", size/1048576);
		}
	}
