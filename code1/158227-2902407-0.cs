        private string GetAppGUID(string sectionId)
        {
            string hexString = null;
            int i = 0;
            int guidLength = 0;
            guidLength = 16;
            if (sectionId.Length < guidLength)
            {
                sectionId = sectionId + new string(" "[0], guidLength - sectionId.Length);
            }
            foreach (char c in sectionId)
            {
                int tmp = c;
                hexString += String.Format("{0:x2}", (uint)System.Convert.ToUInt32(tmp.ToString()))
            }
            return hexString;
        } 
