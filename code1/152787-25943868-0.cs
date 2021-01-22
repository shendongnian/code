    string getSubString(string value, int index, int length)
            {
                if (string.IsNullOrEmpty(value) || value.Length <= length)
                {
                    return value;
                }
                string temp = "";
                for (int i = index; i < length; i++)
                {
                    temp += value[i].ToString();
                }
                return temp;
            }
