            string[] keys = Request.QueryString.AllKeys;
            Array.Sort(keys);
            StringBuilder sb = new StringBuilder();
            foreach (string key in keys)
            {
                if (key.IndexOf("pages_")!=-1)
                {
                    sb.Append(Request.QueryString[key]);
                }
            }
            // sb container the all values
