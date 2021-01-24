     public JsonResult GetAvailableDateInStrings()
        {
            List<string> dateList = new List<string>();
            foreach (Year year in this.m_years)
            {
                foreach (Month month in year.GetMonths())
                {
                    string monthString = month.MonthInEnum.ToString() + " " + year.CalendarYear.ToString();
                    if (year.CalendarYear == this.m_cutOffYear && month.MonthInYear <= this.m_cutOffMonth)
                    {
                        dateList.Add(monthString);
                    }
                    else if (year.CalendarYear < this.m_cutOffYear)
                    {
                        dateList.Add(monthString);
                    }
                }
            }
            return Json(dateList);
        }
