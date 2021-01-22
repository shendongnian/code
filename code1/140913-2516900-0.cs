    parts = original.Split(record);
            for(int i = parts.Length -1; i >= 0; i--)
            {
                string s = parts[i];
                string nString =String.Empty;
                if (s.StartsWith("PLB"))
                {
                    string[] elems = s.Split(elem);
                    if (elems[3].Contains("49" + subelem.ToString()))
                    {
                        string regex = string.Format(@"(\{0})49({1})", elem, subelem);
                        nString = Regex.Replace(s, regex, @"$1CS$2");
                    }
