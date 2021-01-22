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
