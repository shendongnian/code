        int row = 1, col = 1;
        for (int i = 0; i < ix; i++)
        {
            char ch = str[i];
            if (ch == '\r')
            {
                // Skip the optional \n
                if (i + 1 < ix && str[i + 1] == '\n')
                {
                    i++;
                }
                row++;
                col = 1;
            }
            else if (ch == '\n')
            {
                row++;
                col = 1;
            }
            else
            {
                col++;
            }
        }
        return (row, col);
    }
