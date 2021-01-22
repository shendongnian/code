            public DateTime RetrieveLinkerTimestamp(string filePath)
        {
            const int PeHeaderOffset = 60;
            const int LinkerTimestampOffset = 8;
            byte[] b = new byte[2048];
            Stream s = Stream.Null;
            try
            {
                s = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                s.Read(b, 0, 2048);
            }
            finally
            {
                if ((s != null)) s.Close();
            }
            int i = BitConverter.ToInt32(b, PeHeaderOffset);
            int SecondsSince1970 = BitConverter.ToInt32(b, i + LinkerTimestampOffset);
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0);
            dt = dt.AddSeconds(SecondsSince1970);
            dt = dt.AddHours(TimeZone.CurrentTimeZone.GetUtcOffset(dt).Hours);
            return dt;
        }
