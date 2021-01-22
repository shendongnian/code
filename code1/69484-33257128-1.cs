    			private static IDictionary<DriveInfo, string> GetMappedNetworkDrives()
			{
				var rawDrives = new IWshRuntimeLibrary.IWshNetwork_Class()
					.EnumNetworkDrives();
				var result = new Dictionary<DriveInfo, string>(
					rawDrives.length / 2);
				for (int i = 0; i < rawDrives.length; i += 2)
				{
					result.Add(
						new DriveInfo(rawDrives.Item(i)),
						rawDrives.Item(i + 1));
				}
				return result;
			}
