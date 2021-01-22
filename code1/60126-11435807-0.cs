    	Assembly zip_assembly = Assembly.LoadFrom(@"C:\Ionic.Zip.Reduced.dll");
				Type ZipFileType = zip_assembly.GetType("Ionic.Zip.ZipFile");
				Type ZipFileEntryType = zip_assembly.GetType("Ionic.Zip.ZipEntry");
				string local_zip_file = @"C:\zipfile.zip";
				object zip_file = ZipFileType.GetMethod("Read", new Type[] { typeof(string) }).Invoke(null, new object[] { local_zip_file });
				// Entries is ICollection<ZipEntry>
				IEnumerable entries = (IEnumerable)ZipFileType.GetProperty("Entries").GetValue(zip_file, null);
				foreach (object entry in entries)
				{
					string file_name = (string)ZipFileEntryType.GetProperty("FileName").GetValue(entry, null);
					Console.WriteLine(file_name);
				}
