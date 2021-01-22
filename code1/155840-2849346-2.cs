    public bool GetDate(int year, int month, int day, out DateTime dateTime)
    {
        if (month > 0 && month <= 12)
        {
            int daysInMonth = DateTime.DaysInMonth(year, month);
            if (day <= daysInMonth)
            {
                dateTime = new DateTime(year, month, day);
                return true;
            }
        }
        dateTime = new DateTime();
        return false;
    }
