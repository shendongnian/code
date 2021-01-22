        public static string SplitByLength(string s, int length)
        {
            ArrayList sArrReturn = new ArrayList();
            String[] sArr = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string sconcat in sArr)
            {
                if (((String.Join(" ", sArrReturn.ToArray()).Length + sconcat.Length)+1) < length)
                    sArrReturn.Add(sconcat);
                else
                    break;
            }
            return String.Join(" ", sArrReturn.ToArray());
        }
        public static string SplitByLengthOld(string s, int length)
        {
            try
            {
                string sret = string.Empty;
                String[] sArr = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string sconcat in sArr)
                {
                    if ((sret.Length + sconcat.Length + 1) < length)
                        sret = string.Format("{0}{1}{2}", sret, string.IsNullOrEmpty(sret) ? string.Empty : " ", sconcat);
                }
                return sret;
            }
            catch
            {
                return string.Empty;
            }
        }
