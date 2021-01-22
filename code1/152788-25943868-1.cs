    string getSubString(string value, int index, int length)
            {
                if (string.IsNullOrEmpty(value) || value.Length <= length)
                {
                    return value;
                }
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = index; i < length; i++)
                {
                    sb.AppendLine(value[i].ToString());
                }
                return sb.ToString();
            }
