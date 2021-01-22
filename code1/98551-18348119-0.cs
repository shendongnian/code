        public static async Task<DateTimeOffset?> RetrieveLinkerTimestamp(Assembly assembly)
        {
            var pkg = Windows.ApplicationModel.Package.Current;
            if (null == pkg)
            {
                return null;
            }
            var assemblyFile = await pkg.InstalledLocation.GetFileAsync(assembly.ManifestModule.Name);
            if (null == assemblyFile)
            {
                return null;
            }
            using (var stream = await assemblyFile.OpenSequentialReadAsync())
            {
                using (var reader = new DataReader(stream))
                {
                    const int PeHeaderOffset = 60;
                    const int LinkerTimestampOffset = 8;
                    //read first 2048 bytes from the assembly file.
                    byte[] b = new byte[2048];
                    await reader.LoadAsync((uint)b.Length);
                    reader.ReadBytes(b);
                    reader.DetachStream();
                    //get the pe header offset
                    int i = System.BitConverter.ToInt32(b, PeHeaderOffset);
                    //read the linker timestamp from the PE header
                    int secondsSince1970 = System.BitConverter.ToInt32(b, i + LinkerTimestampOffset);
                    var dt = new DateTimeOffset(1970, 1, 1, 0, 0, 0, DateTimeOffset.Now.Offset) + DateTimeOffset.Now.Offset;
                    return dt.AddSeconds(secondsSince1970);
                }
            }
        }
