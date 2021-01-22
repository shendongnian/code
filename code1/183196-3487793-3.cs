        for (int i = 1; i < list.Count(); i++)
        {
            if (list[i].From == list[i - 1].To)
            {
                list[i - 1].To = list[i].To;
                list.RemoveAt(i);
            }
        }
