        public static byte[] doFetchBinaryUrl(string url)
        {
            BinaryReader rdr;
            HttpWebResponse res;
            try
            {
                res = fetch(url);
                rdr = new BinaryReader(res.GetResponseStream());
            }
            catch (NullReferenceException nre)
            {
                return new byte[] { };
            }
            int len = int.Parse(res.GetResponseHeader("Content-Length"));
            byte[] rv = new byte[len];
            for (int i = 0; i < len - 1; i++)
            {
                rv[i] = rdr.ReadByte();
            }
            res.Close();
            return rv;
        }
