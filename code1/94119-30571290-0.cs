    public static List<int> GetDurationInEnglish(DateTime from, DateTime to)
        {
            try
            {
                if (from > to)
                    return null;
                var fY = from.Year;
                var fM = from.Month;
                var fD = DateTime.DaysInMonth(fY, fM);
                var tY = to.Year;
                var tM = to.Month;
                var tD = DateTime.DaysInMonth(tY, tM);
                int dY = 0;
                int dM = 0;
                int dD = 0;
                if (fD > tD)
                {
                    tM--;
                    if (tM <= 0)
                    {
                        tY--;
                        tM = 12;
                        tD += DateTime.DaysInMonth(tY, tM);
                    }
                    else
                    {
                        tD += DateTime.DaysInMonth(tY, tM);
                    }
                }
                dD = tD - fD;
                if (fM > tM)
                {
                    tY--;
                    tM += 12;
                }
                dM = tM - fM;
                dY = tY - fY;
                return new List<int>() { dY, dM, dD };
            }
            catch (Exception exception)
            {
                //todo: log exception with parameters in db
                return null;
            }
        }
