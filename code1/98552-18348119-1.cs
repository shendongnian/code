        public static async Task<DateTimeOffset?> RetrieveLinkerTimestampAsync(Assembly assembly)
        {
            const int PeHeaderOffset = 60;
            const int LinkerTimestampOffset = 8;            
            byte[] b = new byte[2048];
            try
            {
                var rs = Application.GetResourceStream(new Uri(assembly.ManifestModule.Name, UriKind.Relative));
                using (var s = rs.Stream)
                {
                    var asyncResult = s.BeginRead(b, 0, b.Length, null, null);
                    int bytesRead = await Task.Factory.FromAsync<int>(asyncResult, s.EndRead);
                }
            }
            catch (System.IO.IOException)
            {
                return null;
            }
            int i = System.BitConverter.ToInt32(b, PeHeaderOffset);
            int secondsSince1970 = System.BitConverter.ToInt32(b, i + LinkerTimestampOffset);
            var dt = new DateTimeOffset(1970, 1, 1, 0, 0, 0, DateTimeOffset.Now.Offset) + DateTimeOffset.Now.Offset;
            dt = dt.AddSeconds(secondsSince1970);
            return dt;
        }
