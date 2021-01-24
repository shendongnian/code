    if (strName.Contains(".") || strName.Contains("-"))
                {
                    strName = strName.Replace(".", "").Replace("-", "");
                    entry.Text = strName;
                }
