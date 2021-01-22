                StringBuilder sb = new StringBuilder(path.VirtualPath.ToLower());
                string condition = string.Empty;
                int index = path.VirtualPath.IndexOf("?");
                if (index > -1)
                {
                    condition = virtualPath.Substring(pos);
                    sb.Remove(0, index);
                }
                
                sb.Replace(@"%C5%BD", "ž")
                    .Replace(@"%C4%90", "đ")
                    .Replace(@"%C4%86", "ć")
                    .Replace(@"%C4%8C", "č")
                    .Replace(@"%C5%A0", "š")
                    .Replace(",", "-")
                    .Replace("%20", "-")
                    .Replace("&", "-")
                    .Replace(@"-amp;", "&");
                 sb.Append(condition);
