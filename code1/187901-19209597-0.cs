		private DataTable GetSharedFolderAccessRule()
		{
			DataTable DT = new DataTable();
			try
			{
				DT.Columns.Add("ShareName");
				DT.Columns.Add("Caption");
				DT.Columns.Add("Path");
				DT.Columns.Add("Domain");
				DT.Columns.Add("User");
				DT.Columns.Add("AccessMask");
				DT.Columns.Add("AceType");
				ManagementScope Scope = new ManagementScope(@"\\.\root\cimv2");
				Scope.Connect();
				ObjectQuery Query = new ObjectQuery("SELECT * FROM Win32_LogicalShareSecuritySetting");
				ManagementObjectSearcher Searcher = new ManagementObjectSearcher(Scope, Query);
				ManagementObjectCollection QueryCollection = Searcher.Get();
				foreach (ManagementObject SharedFolder in QueryCollection)
				{
					{
						String ShareName = (String) SharedFolder["Name"];
						String Caption   = (String)SharedFolder["Caption"];
						String LocalPath = String.Empty;
						ManagementObjectSearcher Win32Share = new ManagementObjectSearcher("SELECT Path FROM Win32_share WHERE Name = '" + ShareName + "'");
						foreach (ManagementObject ShareData in Win32Share.Get())
						{
							LocalPath = (String) ShareData["Path"];
						}
						ManagementBaseObject Method = SharedFolder.InvokeMethod("GetSecurityDescriptor", null, new InvokeMethodOptions());
						ManagementBaseObject Descriptor = (ManagementBaseObject)Method["Descriptor"];
						ManagementBaseObject[] DACL = (ManagementBaseObject[])Descriptor["DACL"];
						foreach (ManagementBaseObject ACE in DACL)
						{
							ManagementBaseObject Trustee = (ManagementBaseObject)ACE["Trustee"];
							// Full Access = 2032127, Modify = 1245631, Read Write = 118009, Read Only = 1179817
							DataRow Row = DT.NewRow();
							Row["ShareName"]  = ShareName;
							Row["Caption"]    = Caption;
							Row["Path"]       = LocalPath;
							Row["Domain"]     = (String) Trustee["Domain"];
							Row["User"]       = (String) Trustee["Name"];
							Row["AccessMask"] = (UInt32) ACE["AccessMask"];
							Row["AceType"]    = (UInt32) ACE["AceType"];
							DT.Rows.Add(Row);
							DT.AcceptChanges();
						}
					}
				}
			}
			catch (Exception ex) 
			{
				MessageBox.Show(ex.StackTrace, ex.Message);
			}
			return DT;
		}
