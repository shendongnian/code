        public int CalculateCoverageOne(DateTime dateCurrentDate, DateTime dateEffectiveDate, DateTime dateEffDateOne, DateTime dateEndDateOne)
        {
            //Coverage1=
            //IIf(IsNull([EffDate1]),0,
                //IIf([CurrDate]<=[EndDate1],
                    //[CurrDate]-[EffDate1],
                        //[EndDate1]-[EffDate1]+1))
            if (dateEffDateOne.Equals(TimeSpan.Zero))
            {
                return (TimeSpan.Zero).Days;
            }
            else
            {
                if (dateEffectiveDate <= dateEndDateOne)
                {
                    return (dateCurrentDate - dateEffDateOne).Days;
                }
                else
                {
                    return (dateEndDateOne - dateEffDateOne).Add(new TimeSpan(1, 0, 0, 0)).Days;
                }
            }
        }
