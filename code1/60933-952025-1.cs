        public string dictonaryToString(Dictionary<string, string> nvc, char KeyValueSeparator, char ItemSeparator)
        {
            StringBuilder sb = new StringBuilder();
            bool first = true;
            foreach (KeyValuePair<string,string> kvp in nvc)
            {
                if (!first)
                {
                    sb.Append(ItemSeparator);
                    first = false;
                }
                sb.Append(kvp.Key);
                sb.Append(KeyValueSeparator);
                sb.Append(kvp.Value);
            }
            return sb.ToString();
        }
    }
