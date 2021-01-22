        DateTime NextAugust(DateTime inputDate)
        {
            if (inputDate.Month <= 8)
            {
                return new DateTime(inputDate.Year, 8, 31);
            }
            else
            {
                return new DateTime(inputDate.Year+1, 8, 31);
            }
        }
