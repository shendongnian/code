        DateTime NextAugust(DateTime inputDate)
        {
            if (inputDate.Month <= 8)
            {
                return new DateTime(inputDate.Year, inputDate.Month, 1);
            }
            else
            {
                return new DateTime(inputDate.Year+1, inputDate.Month, 1);
            }
        }
