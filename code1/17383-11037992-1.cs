    static string AddSpacesToColumnName(string columnCaption)
        {
            if (string.IsNullOrWhiteSpace(columnCaption))
                return "";
            StringBuilder newCaption = new StringBuilder(columnCaption.Length * 2);
            newCaption.Append(columnCaption[0]);
            int pos = 1;
            for (pos = 1; pos < columnCaption.Length-1; pos++)
            {               
                if (char.IsUpper(columnCaption[pos]) && !(char.IsUpper(columnCaption[pos - 1]) && char.IsUpper(columnCaption[pos + 1])))
                    newCaption.Append(' ');
                newCaption.Append(columnCaption[pos]);
            }
            newCaption.Append(columnCaption[pos]);
            return newCaption.ToString();
        }
