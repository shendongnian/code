        class FancyDate
        {
            public int Month { get; set; }
            public int Day { get; set; }
            public FancyDate(string fancyDate)
            {
                var split = fancyDate.Split('-');
                Month = Int32.Parse(split[0]);
                Day = Int32.Parse(split[1]);
            }
            public override string ToString()
            {
                return $"{Month}-{Day}";
            }
        }
        class FancyDateList
        {
            private List<FancyDate> theDateList;
            public FancyDateList(List<string> dates)
            {
                dates.Sort();
                theDateList = new List<FancyDate>();
                foreach (var date in dates)
                {
                    theDateList.Add(new FancyDate(date));
                }
            }
            private List<FancyDate> RotateListForCurrentDate()
            {
                // Bit of indirection to aid testing
                return RotateListForDate(DateTime.Now);
            }
            public List<FancyDate> RotateListForDate(DateTime dateTime)
            {
                var month = dateTime.Month;
                var day = dateTime.Day;
                int i = 0;
                while(i < theDateList.Count)
                {
                    if (theDateList[i].Month < month)
                    {
                        i++;
                        continue;
                    }
                    if (theDateList[i].Month == month)
                    {
                        while (theDateList[i].Day < day)
                        {
                            i++;
                        }
                    }
                    if (theDateList[i].Month > month) break;
                    if (theDateList[i].Month >= month && theDateList[i].Day >= day) break;
                }
                return theDateList.Skip(i).Concat(theDateList.Take(i)).ToList();
            }
            public List<FancyDate> GetListForDisplay()
            {
                return RotateListForCurrentDate();
            }
        }
