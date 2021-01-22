    			if ( entry.CentralHeaderRequiresZip64 ) {
				ed.StartNewEntry();
                if ((entry.Size >= 0xffffffff) || (useZip64_ == UseZip64.On) || entry.IsZip64Forced())
				{
					ed.AddLeLong(entry.Size);
				}
                if ((entry.CompressedSize >= 0xffffffff) || (useZip64_ == UseZip64.On) || entry.IsZip64Forced())
				{
					ed.AddLeLong(entry.CompressedSize);
				}
