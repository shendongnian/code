        for (int i = 1; i < list.Count(); i++)
        {
            if (list[i].From == list[i - 1].To+1  && list[i-1].Category == list[i].Category)
            {
                list[i - 1].To = list[i].To;
                list.RemoveAt(i--);
            }
        }
