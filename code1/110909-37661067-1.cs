     Using an extencion to DateTime:  
            public enum eTimeFragment
            {
                hours,
                minutes,
                seconds,
                milliseconds
            }
            public static DateTime ClearTimeFrom(this DateTime dateToClear, eTimeFragment etf)
            {
                DateTime dtRet = dateToClear;
                switch (etf)
                {
                    case eTimeFragment.hours:
                        dtRet = dateToClear.Date;
                        break;
                    case eTimeFragment.minutes:
                        dtRet = dateToClear.AddMinutes(dateToClear.Minute * -1);
                        dtRet = dtRet.ClearTimeFrom(eTimeFragment.seconds);
                        break;
                    case eTimeFragment.seconds:
                        dtRet = dateToClear.AddSeconds(dateToClear.Second * -1);
                        dtRet = dtRet.ClearTimeFrom(eTimeFragment.milliseconds);
                        break;
                    case eTimeFragment.milliseconds:
                        dtRet = dateToClear.AddMilliseconds(dateToClear.Millisecond * -1);
                        break;
                }
                return dtRet;
                
            }
