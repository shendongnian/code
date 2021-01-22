        StringBuilder stringBuilder = new StringBuilder();
        for (int row = 0; row < table.GetLength(0); ++row)
        {
            stringBuilder.Append(row.ToString() + "\t");
            for (int column = 0; column < table.GetLength(1); ++column)
            {
                for (int valueIndex = 0; valueIndex < table.GetLength(2); ++valueIndex)
                {
                    stringBuilder.Append(table[row, column, valueIndex].ToString());
                }
                stringBuilder.Append("\t");
            }
            stringBuilder.AppendLine();
        }
        string result = stringBuilder.ToString();
        Console.WriteLine(result);
