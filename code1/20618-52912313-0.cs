    model.Controls = new
    {
        FiscalMonths = new
        {
            Value = DateTime.Now.Month,
            Options = (new List<int> { 10, 11, 12, 1, 2, 3, 4, 5, 6, 7, 8, 9 }).Select(p => new
            {
                Value = p,
                Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(p)
            })
        }
    };
