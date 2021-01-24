        /// <summary>
        /// 
        /// </summary>
        /// <param name="startTime">First Datetime</param>
        /// <param name="span">12 hours in your case</param>
        /// <returns></returns>
        public bool AnyNightHoursIncluded(DateTime startTime, int span)
        {
            int startHour = Convert.ToInt32(startTime.ToString("HH")); //24 hour format
            for (int i = 0; i < span; i++)
            {
                int actualHourValue = Convert.ToInt32(startTime.AddHours(i).ToString("HH"));
                //from 0:00 to 6:00
                if (actualHourValue >= 0 && actualHourValue < 6)
                    return true;      
            }
            return false;
        }
