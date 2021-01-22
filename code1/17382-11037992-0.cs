     static string AddSpacesToColumnName(string columnCaption)
        {
            if (string.IsNullOrWhiteSpace(columnCaption))
                return "";
            StringBuilder newCaption = new StringBuilder(columnCaption.Length * 2);
            newCaption.Append(columnCaption[0]);
            for (int pos = 1; pos < columnCaption.Length; pos++)
            {
                if ((char.IsUpper(columnCaption[pos])) && (columnCaption[pos - 1] != ' ') && (!char.IsUpper(columnCaption[pos - 1])))
                    newCaption.Append(' ');
                newCaption.Append(columnCaption[pos]);
            }
            return newCaption.ToString();
        }
